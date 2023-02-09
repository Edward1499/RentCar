import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { VehicleService } from '../services/vehicle.service';
import swal from 'sweetalert2';
import { VehicleTypeService } from '../../vehicle-type/services/vehicle-type.service';
import { BrandService } from '../../brand/services/brand.service';
import { FuelService } from '../../fuel/services/fuel.service';
import { ModelService } from '../../model/services/model.service';
import {CdkDragDrop, moveItemInArray} from '@angular/cdk/drag-drop';
import { FileService } from 'src/app/shared/services/file.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit {

  form: FormGroup = this.fb.group({
    description: [null, [Validators.required]],
    chasisNumber: [null, [Validators.required]],
    engineNumber: [null, [Validators.required]],
    licensePlate: [null, [Validators.required]],
    year: [null, [Validators.required]],
    vehicleTypeId: [null, [Validators.required]],
    brandId: [null, [Validators.required]],
    modelId: [null, [Validators.required]],
    fuelId: [null, [Validators.required]],
    isActive: [false, [Validators.required]],
  });

  vehicleTypes: any[] = [];
  brands: any[] = [];
  models: any[] = [];
  fuels: any[] = [];
  years: any[] = [];

  files: any[] = [];

  @ViewChild('fileInput') fileInput!: ElementRef;

  images: any[] = [];

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private vehicleService: VehicleService,
    private vehicleTypeService: VehicleTypeService,
    private brandService: BrandService,
    private fuelService: FuelService,
    private modelService: ModelService,
    private fileService: FileService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.vehicleTypeService.getAllActives()
      .subscribe(data => this.vehicleTypes = data);
    this.brandService.getAllActives()
      .subscribe(data => this.brands = data);
    this.fuelService.getAllActives()
      .subscribe(data => this.fuels = data);

    this.setYears();
  }

  private setYears() {
    for (let year = 1990; year < 2024; year++) {
      this.years.push(year);
    }
  }

  onChangeBrand(event: any) {
    if (event.target.value) {
      this.modelService.getByBrandId(event.target.value)
        .subscribe(data => this.models = data);
    }
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.images, event.previousIndex, event.currentIndex);
  }

  onRemoveImage(index: number) {
    this.images.splice(index, 1);
  }

  onUpload() {
    this.fileInput.nativeElement.click();
  }

  onChangeFileInput(event: any) {
    for (let index = 0; index < event.target.files.length; index++) {
      const file = event.target.files[index];
      this.fileService.upload(file)
        .subscribe(image => {
          this.images.push(image);
        });
    }
    console.log(this.images);
  }

  save() {
    const { brandId, modelId, vehicleTypeId, year} = this.form.getRawValue(); 
    const request = {
      ...this.form.getRawValue(),
      brandId: +brandId,
      modelId: +modelId,
      vehicleTypeId: +vehicleTypeId,
      year: +year,
      images: this.images.map(image => ({ imageUrl:  image}))
    }
    console.log(request);
    this.vehicleService.add(request)
      .subscribe(() => {
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.router.navigate(['/vehiculos']);
      }); 

    //   if (this.id) {
    //     this.vehicleService.update(this.id, this.form.getRawValue())
    //     .subscribe(() => {
    //       this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
    //     }); 
    //   } else {
        
    // }

  }

}

