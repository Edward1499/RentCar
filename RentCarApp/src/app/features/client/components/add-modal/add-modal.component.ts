import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ClientService } from '../../services/client.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-add-modal',
  templateUrl: './add-modal.component.html',
  styleUrls: ['./add-modal.component.scss']
})
export class AddModalComponent {

  form: FormGroup = this.fb.group({
    name: [null, [Validators.required]],
    lastName: [null, [Validators.required]],
    personalNumber: [null, [Validators.required]],
    personType: [null, [Validators.required]],
    creditLimit: [null, [Validators.required]],
    CRNumber: [null, [Validators.required]],
    CRName: [null, [Validators.required]],
    CRExpiration: [null, [Validators.required]],
    CRCCVNumber: [null, [Validators.required, Validators.min(111), Validators.max(9999)]],
  });

  @Input() public id!: number;

  @ViewChild('fieldName') fieldName!: ElementRef;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private clientService: ClientService
  ) { }


  ngOnInit(): void {
    if (this.id) {
      this.clientService.get(this.id)
        .subscribe(data => {
          this.form.controls['name'].setValue(data.name);
          this.form.controls['lastName'].setValue(data.lastName);
          this.form.controls['personalNumber'].setValue(data.personalNumber);
          this.form.controls['personType'].setValue(data.personType);
          this.form.controls['creditLimit'].setValue(data.creditLimit);
          this.fieldName.nativeElement.focus();
          this.form.controls['CRNumber'].setValue(data.crNumber);
          this.fieldName.nativeElement.blur();
          this.form.controls['CRName'].setValue(data.crName);
          this.form.controls['CRExpiration'].setValue(data.crExpiration);
          this.form.controls['CRCCVNumber'].setValue(data.crccvNumber);
        });
    }
  }


  onChangePersontype(target: any) {
    this.form.controls['personalNumber'].setValue(null);
    if (target.value == 1) {
      this.form.controls['personalNumber'].setValidators([Validators.required, Validators.min(10000000000), Validators.max(99999999999)]);
    } else {
      this.form.controls['personalNumber'].setValidators([Validators.required, Validators.min(100000000), Validators.max(999999999)]);
    }

    this.form.controls['personalNumber'].updateValueAndValidity();
  }

  onClose() {
    this.modalService.dismissAll();
  }

  save() {
    this.form.get('personType')?.setValue(+this.form.get('personType')?.value);
    this.form.get('personalNumber')?.setValue(this.form.get('personalNumber')?.value?.toString());
    console.log(this.form.getRawValue());

    if (this.form.get('personType')?.value === 1) {
      this.clientService.isValidPersonalNumber(this.form.get('personalNumber')?.value)
      .subscribe(isValid => {
        if (isValid) {
          this.saveData();
        } else {
          swal.fire({
            icon: 'error',
            title: 'Error...',
            text: 'Introduzca una cedula valida!',
          });
        }
      });
    } else {
      this.saveData();
    }   
  }

  private saveData() {
    if (this.id) {
      this.clientService.update(this.id, this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.clientService.setClients();
      }); 
    } else {
      this.clientService.add(this.form.getRawValue())
      .subscribe(() => {
        this.modalService.dismissAll();
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.clientService.setClients();
      }); 
    } 
  }
}
