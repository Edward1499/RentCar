import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDate, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ClientService } from '../../../client/services/client.service';
import swal from 'sweetalert2';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-add-modal',
  templateUrl: './add-modal.component.html',
  styleUrls: ['./add-modal.component.scss']
})
export class AddModalComponent {

  form: FormGroup = this.fb.group({
    name: [null, [Validators.required]],
    lastName: [null, [Validators.required]],
    personalNumber: [null, [Validators.required, Validators.min(10000000000), Validators.max(99999999999)]],
    batchWork: [null, [Validators.required]],
    commissionPercentage: [null, [Validators.required]],
    startDate: [null, [Validators.required]],
  });

  @Input() public id!: number;


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private clientService: ClientService,
    private employeeService: EmployeeService
  ) { }


  ngOnInit(): void {
    if (this.id) {
      this.employeeService.get(this.id)
        .subscribe(data => {
          this.form.controls['name'].setValue(data.name);
          this.form.controls['lastName'].setValue(data.lastName);
          this.form.controls['personalNumber'].setValue(data.personalNumber);
          this.form.controls['batchWork'].setValue(data.batchWork);
          this.form.controls['commissionPercentage'].setValue(data.commissionPercentage);
          const date = new Date(data.startDate);
          this.form.controls['startDate'].setValue(new NgbDate(date.getUTCFullYear(), date.getUTCMonth() + 1, date.getUTCDate()));
          // this.form.controls['startDate'].setValue({
          //   "year": data.startDate.getUTCFullYear(),
          //   "month": data.startDate.getUTCMonth() + 1,
          //   "day": 8
          // });

        });
    }
  }

  onClose() {
    this.modalService.dismissAll();
  }

  save() {
    console.log(this.form.getRawValue());

    this.clientService.isValidPersonalNumber(this.form.get('personalNumber')?.value)
      .subscribe(isValid => {
        if (isValid) {
          this.form.get('batchWork')?.setValue(+this.form.get('batchWork')?.value);
          this.form.get('personalNumber')?.setValue(this.form.get('personalNumber')?.value?.toString());
          const { year, month, day } = this.form.get('startDate')?.value;
          this.form.get('startDate')?.setValue(new Date(`${year}-${month}-${day}`));
          this.saveData();
        } else {
          swal.fire({
            icon: 'error',
            title: 'Error...',
            text: 'Introduzca una cedula valida!',
          });
        }
      });  
  }

  private saveData() {
    if (this.id) {
      this.employeeService.update(this.id, this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.employeeService.setEmployees();
      }); 
    } else {
      this.employeeService.add(this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.employeeService.setEmployees();
      }); 
    } 
  }

}
