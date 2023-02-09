import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ClientService } from '../../client/services/client.service';
import { EmployeeService } from '../../employee/services/employee.service';
import swal from 'sweetalert2';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.scss']
})
export class TransactionComponent implements OnInit {

  form: FormGroup = this.fb.group({
    vehicleId: [null, [Validators.required]],
    clientId: [null, [Validators.required]],
    employeeId: [null, [Validators.required]],
    hasScratches: [null, [Validators.required]],
    fuelQuantity: [null, [Validators.required]],
    hasSpareTire: [null, [Validators.required]],
    hasHydraulicJack: [null, [Validators.required]],
    hasGlassBreak: [null, [Validators.required]],
    isRightFrontTireOk: [null, [Validators.required]],
    isLeftFrontTireOk: [null, [Validators.required]],
    isRightRearTireOk: [null, [Validators.required]],
    IsLeftRearTireOk: [null, [Validators.required]],
    rentDate: [null, [Validators.required]],
    deliveryDate: [null, [Validators.required]],
    amountDay: [null, [Validators.required]],
    totalDays: [{ value: null, disabled: true }],
    description: [null, [Validators.required]],
  });

  clients: any[] = [];
  employees: any[] = [];

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private clientService: ClientService,
    private employeeService: EmployeeService,
    private activatedRoute: ActivatedRoute,
    private vehicleService: VehicleService
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params
      .subscribe(({id}) => {
        this.form.get('vehicleId')?.setValue(+id);
        console.log(id);
      })
    this.clientService.getAllList() 
      .subscribe(data => {
        this.clients = data;
      });
    this.employeeService.getAllList() 
      .subscribe(data => {
        this.employees = data;
      });

    this.form.get('rentDate')?.valueChanges
      .subscribe(() => {
        this.onChangeDate();
      });

    this.form.get('deliveryDate')?.valueChanges
      .subscribe(() => {
        this.onChangeDate();
      });
  }

  onChangeDate() {
    if (!this.form.get('rentDate')?.value || !this.form.get('deliveryDate')?.value) {
      return;
    }

    const { year: rentDateYear, month: rentDateMonth, day: rentDateDay } = this.form.get('rentDate')?.value;
    const { year: deliveryDateYear, month: deliveryDateMonth, day: deliveryDateDay } = this.form.get('deliveryDate')?.value;

    const rentDate: any = new Date(`${rentDateYear}-${rentDateMonth}-${rentDateDay}`);
    const deliveryDate: any = new Date(`${deliveryDateYear}-${deliveryDateMonth}-${deliveryDateDay}`);

    if (deliveryDate < rentDate) {
      this.form.get('deliveryDate')?.setValue(null);
      swal.fire({
        icon: 'error',
        title: 'Error...',
        text: 'La fecha de entrega no puede ser menor a la fecha de renta!',
      });
      this.form.get('totalDays')?.setValue(null);
      return;
    }
    const diffTime = Math.abs(rentDate - deliveryDate);
    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)); 
    this.form.get('totalDays')?.setValue(diffDays);
  }

  save() {
    this.form.get('clientId')?.setValue(+this.form.get('clientId')?.value);
    this.form.get('employeeId')?.setValue(+this.form.get('employeeId')?.value);

    const { year: rentDateYear, month: rentDateMonth, day: rentDateDay } = this.form.get('rentDate')?.value;
    const { year: deliveryDateYear, month: deliveryDateMonth, day: deliveryDateDay } = this.form.get('deliveryDate')?.value;

    const request = {
      ...this.form.getRawValue(),
      rentDate: new Date(`${rentDateYear}-${rentDateMonth}-${rentDateDay}`),
      deliveryDate: new Date(`${deliveryDateYear}-${deliveryDateMonth}-${deliveryDateDay}`)
    }

    console.log(request);

    this.vehicleService.addTransaction(request)
      .subscribe(() => {
        this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
        this.router.navigate(['/vehiculos']);
      });
  }

}
