import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrandRoutingModule } from './brand-routing.module';
import { ListComponent } from './list/list.component';
import { AddModalComponent } from './components/add-modal/add-modal.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ListComponent,
    AddModalComponent
  ],
  imports: [
    CommonModule,
    BrandRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    NgbDatepickerModule,
    ReactiveFormsModule
  ]
})
export class BrandModule { }
