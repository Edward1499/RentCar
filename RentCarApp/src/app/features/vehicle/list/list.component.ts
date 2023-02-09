import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { combineLatest, of } from 'rxjs';
import { debounceTime, map, mergeMap  } from 'rxjs/operators';
import { BrandService } from '../../brand/services/brand.service';
import { FuelService } from '../../fuel/services/fuel.service';
import { ModelService } from '../../model/services/model.service';
import { VehicleTypeService } from '../../vehicle-type/services/vehicle-type.service';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  form: FormGroup = this.fb.group({
    fuelId: [0, [Validators.required]],
    vehicleTypeId: [0, [Validators.required]],
    year: [0, [Validators.required]],
    brandId: [0, [Validators.required]],
    modelId: [0, [Validators.required]],
    isActive: [undefined, [Validators.required]],
  });

  vehicles: any[] = [];
  fuels: any[] = [];
  vehicleTypes: any[] = [];
  brands: any[] = [];
  models: any[] = [];
  changeRange: boolean = false;
  totalCount!: number;
  pageSize!: number;
  pageNumber: number = 1;

  constructor(
    private vehicleService: VehicleService,
    private fuelService: FuelService,
    private vehicleTypeService: VehicleTypeService,
    private brandService: BrandService,
    private modelService: ModelService,
    private fb: FormBuilder,
  ) {


  }

  ngOnInit(): void {
    this.search();
    this.fuelService.getAllActives()
      .subscribe(data => {
        this.fuels = data;
      });
    this.vehicleTypeService.getAllActives()
      .subscribe(data => {
        this.vehicleTypes = data;
      });
    this.brandService.getAllActives()
      .subscribe(data => {
        this.brands = data;
      });

    // combineLatest({
    //   fuelId: this.form.get('fuelId')?.valueChanges!,
    //   vehicleTypeId: this.form.get('vehicleTypeId')?.valueChanges!,
    //   //brandId: this.form.get('brandId')?.valueChanges!,
    //   modelId: this.form.get('modelId')?.valueChanges!,
    //   isActive: this.form.get('isActive')?.valueChanges!
    // }).pipe(
    //   map((response: any) => {
    //     console.log('Hello!!!')
    //     console.log(response)
    //   })
    // );

      
    // combineLatest([
    //   this.form.get('fuelId')?.valueChanges,
    //   this.form.get('vehicleTypeId')?.valueChanges,
    //   this.form.get('brandId')?.valueChanges,
    //   this.form.get('modelId')?.valueChanges,
    //   this.form.get('isActive')?.valueChanges
    // ]);
  }

  search() {
    const request = {
      pageSize: 9,
      pageIndex: this.pageNumber,
      fuelId: this.form.get('fuelId')?.value,
      vehicleTypeId: this.form.get('vehicleTypeId')?.value,
      brandId: this.form.get('brandId')?.value,
      modelId: this.form.get('modelId')?.value,
      isActive: this.form.get('isActive')?.value,
    }
    this.vehicleService.getAll(request)
      .subscribe(response => {
        this.vehicles = response.data;
        this.totalCount = response.count;
        this.pageSize = response.pageSize;
        this.pageNumber = response.pageIndex;
      });
  }

  onChangeInputs() {
    this.search();
  }

  onChangeBrand() {
    if (this.form.get('brandId')?.value) {
      this.form.get('modelId')?.setValue(0);
      this.modelService.getByBrandId(this.form.get('brandId')?.value)
        .subscribe(data => {
          this.models = data;
          this.onChangeInputs();
        });
    } 
  }

  onPageChanged(page: any) {
    if (this.pageNumber !== page) {
      this.pageNumber = page;
      this.search();
    }
  }

  onSliderChange(selectedValues: number[]) {
    this.changeRange = true;
    setTimeout(() => {
      if (this.changeRange) {
        console.log(selectedValues)
      }
    }, 2000);
    this.changeRange = false;
  }
}
