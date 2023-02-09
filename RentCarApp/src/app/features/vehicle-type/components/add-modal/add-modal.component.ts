import { Component, Input , OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { VehicleTypeService } from '../../services/vehicle-type.service';


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
    private vehicleTypeService: VehicleTypeService
  ) { }


  ngOnInit(): void {
    if (this.id) {
      this.vehicleTypeService.get(this.id)
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
      this.vehicleTypeService.update(this.id, this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.vehicleTypeService.setVehicleTypes();
      }); 
    } else {
      this.vehicleTypeService.add(this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.vehicleTypeService.setVehicleTypes();
      }); 
    } 
  }

}
