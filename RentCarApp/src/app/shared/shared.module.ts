import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { MainComponent } from './layout/main/main.component';
import { RouterModule } from '@angular/router';
import { DeleteModalComponent } from './components/delete-modal/delete-modal.component';
import { ReportModalComponent } from './components/report-modal/report-modal.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { PagerComponent } from './components/pager/pager.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [
    NavbarComponent,
    MainComponent,
    DeleteModalComponent,
    ReportModalComponent,
    PagerComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    NgbDatepickerModule,
    ReactiveFormsModule,
    PaginationModule.forRoot(),
  ],
  exports: [
    NavbarComponent,
    MainComponent,
    PagerComponent
  ]
})
export class SharedModule { }
