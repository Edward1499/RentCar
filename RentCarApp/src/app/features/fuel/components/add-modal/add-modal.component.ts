import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { FuelService } from '../../services/fuel.service';

@Component({
  selector: 'app-add-modal',
  templateUrl: './add-modal.component.html',
  styleUrls: ['./add-modal.component.scss']
})
export class AddModalComponent implements OnInit {

  form: FormGroup = this.fb.group({
    description: [null, [Validators.required]],
    isActive: [true, [Validators.required]]
  });

  @Input() public id!: number;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private fuelService: FuelService
  ) { }


  ngOnInit(): void {
    if (this.id) {
      this.fuelService.get(this.id)
        .subscribe(data => {
          this.form.controls['description'].setValue(data.description);
          this.form.controls['isActive'].setValue(data.isActive);
        });
    }
  }

  onClose() {
    this.modalService.dismissAll();
  }

  save() {
    if (this.id) {
      this.fuelService.update(this.id, this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.fuelService.setFuels();
      }); 
    } else {
      this.fuelService.add(this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.fuelService.setFuels();
      }); 
    } 
  }
}
