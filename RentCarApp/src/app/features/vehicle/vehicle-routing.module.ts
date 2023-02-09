import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddComponent } from './add/add.component';
import { DetailComponent } from './detail/detail.component';
import { ListComponent } from './list/list.component';
import { TransactionComponent } from './transaction/transaction.component';

const routes: Routes = [
  {
    path: '',
    component: ListComponent
  },
  {
    path: 'agregar',
    component: AddComponent
  },
  {
    path: 'detalle/:id',
    component: DetailComponent
  },
  {
    path: 'rentar/:id',
    component: TransactionComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehicleRoutingModule { }
