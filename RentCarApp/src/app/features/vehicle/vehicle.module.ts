import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VehicleRoutingModule } from './vehicle-routing.module';
import { ListComponent } from './list/list.component';
import { NpnSliderModule } from 'npn-slider';
import { AddComponent } from './add/add.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { DetailComponent } from './detail/detail.component';
import { GalleryModule } from 'ng-gallery';
import { LightboxModule } from 'ng-gallery/lightbox';
import { TransactionComponent } from './transaction/transaction.component';
import { CompleteTransactionComponent } from './components/complete-transaction/complete-transaction.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    ListComponent,
    AddComponent,
    DetailComponent,
    TransactionComponent,
    CompleteTransactionComponent
  ],
  imports: [
    CommonModule,
    VehicleRoutingModule,
    NpnSliderModule,
    MatTableModule,
    MatPaginatorModule,
    NgbDatepickerModule,
    ReactiveFormsModule,
    DragDropModule,
    GalleryModule.withConfig({
      // thumbView: 'contain',
    }),
    LightboxModule,
    SharedModule
  ]
})
export class VehicleModule { }
