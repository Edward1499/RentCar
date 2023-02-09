import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VehicleTypeRoutingModule } from './vehicle-type-routing.module';
import { ListComponent } from './list/list.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { AddModalComponent } from './components/add-modal/add-modal.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ListComponent,
    AddModalComponent
  ],
  imports: [
    CommonModule,
    VehicleTypeRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    NgbDatepickerModule,
    ReactiveFormsModule
  ]
})
export class VehicleTypeModule { }
