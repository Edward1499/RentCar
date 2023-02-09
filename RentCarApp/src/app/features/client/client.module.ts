import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientRoutingModule } from './client-routing.module';
import { ListComponent } from './list/list.component';
import { AddModalComponent } from './components/add-modal/add-modal.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import {CardModule} from 'ngx-card';

@NgModule({
  declarations: [
    ListComponent,
    AddModalComponent
  ],
  imports: [
    CommonModule,
    ClientRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    NgbDatepickerModule,
    ReactiveFormsModule,
    CardModule
  ]
})
export class ClientModule { }
