import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FuelRoutingModule } from './fuel-routing.module';
import { AddModalComponent } from './components/add-modal/add-modal.component';
import { ListComponent } from './list/list.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddModalComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    FuelRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    NgbDatepickerModule,
    ReactiveFormsModule
  ]
})
export class FuelModule { }
