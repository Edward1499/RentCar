import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from '../shared/layout/main/main.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: 'clientes',
        loadChildren: () => import('./client/client.module').then(m => m.ClientModule),
      },
      {
        path: 'vehiculos',
        loadChildren: () => import('./vehicle/vehicle.module').then(m => m.VehicleModule),
      },
      {
        path: 'tipos-vehiculos',
        loadChildren: () => import('./vehicle-type/vehicle-type.module').then(m => m.VehicleTypeModule),
      },
      {
        path: 'marcas',
        loadChildren: () => import('./brand/brand.module').then(m => m.BrandModule),
      },
      {
        path: 'modelos',
        loadChildren: () => import('./model/model.module').then(m => m.ModelModule),
      },
      {
        path: 'combustibles',
        loadChildren: () => import('./fuel/fuel.module').then(m => m.FuelModule),
      },
      {
        path: 'empleados',
        loadChildren: () => import('./employee/employee.module').then(m => m.EmployeeModule),
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }
