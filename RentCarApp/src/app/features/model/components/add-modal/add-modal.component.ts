import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { BrandService } from 'src/app/features/brand/services/brand.service';
import { ModelService } from '../../services/model.service';

@Component({
  selector: 'app-add-modal',
  templateUrl: './add-modal.component.html',
  styleUrls: ['./add-modal.component.scss']
})
export class AddModalComponent implements OnInit {

  form: FormGroup = this.fb.group({
    description: [null, [Validators.required]],
    isActive: [true, [Validators.required]],
    brandId: [null, [Validators.required]],
  });

  @Input() public id!: number;

  brands: any[] = [];

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private model: ModelService,
    private brandService: BrandService
  ) { }


  ngOnInit(): void {

    this.brandService.getAllActives()
    .subscribe(data => {
      this.brands = data;
      
    }); 

    if (this.id) {
      this.model.get(this.id)
        .subscribe(data => {
          this.form.controls['description'].setValue(data.description);
          this.form.controls['isActive'].setValue(data.isActive);
          this.form.controls['brandId'].setValue(data.brandId);
        });
    }
  }

  onClose() {
    this.modalService.dismissAll();
  }

  save() {
    if (this.id) {
      this.model.update(this.id, this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.model.setModels();
      }); 
    } else {
      this.model.add(this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.model.setModels();
      }); 
    } 
  }
}
