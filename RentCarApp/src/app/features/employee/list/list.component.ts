import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { DeleteModalComponent } from 'src/app/shared/components/delete-modal/delete-modal.component';
import { AddModalComponent } from '../components/add-modal/add-modal.component';
import { EmployeeService } from '../services/employee.service';

interface Employee {
  id: number;
  description: string;
  isActive: number;
  createdAt: Date;
  updatedAt: Date;
}

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent {

  displayedColumns: string[] = ['name', 'personalNumber', 'batchWork', 'startDate', 'actions'];
  dataSource = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private modalService: NgbModal,
    private employeeService: EmployeeService,
    private toastr: ToastrService,
  ) {}

  ngOnInit(): void {
    this.employeeService.getAll
      .subscribe(data => {
        this.dataSource.data = data;
      });

  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  open(id?: number) {
    const modalRef = this.modalService.open(AddModalComponent, { ariaLabelledBy: 'modal-basic-title', size: 'lg' });
    if (id) {
      modalRef.componentInstance.id = id;
    }
	}

  onRemove(id: number) {
    this.modalService.open(DeleteModalComponent, { ariaLabelledBy: 'modal-basic-title' }).result
      .then(_ => {}
      ,(reason) => {
        if (reason === 'remove') {
          this.employeeService.delete(id)
            .subscribe(() => {
              this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
              this.employeeService.setEmployees();
            });
        }
      });
  }

}
