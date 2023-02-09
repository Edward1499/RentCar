import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { DeleteModalComponent } from 'src/app/shared/components/delete-modal/delete-modal.component';
import { AddModalComponent } from '../components/add-modal/add-modal.component';
import { ClientService } from '../services/client.service';

interface Client {
  id: number;
  crExpiration: string;
  crNumber: string;
  crccvNumber: number;
  creditLimit: number;
  lastName: string;
  name: string;
  personType: string;
  personalNumber: string;
  createdAt: Date;
  updatedAt: Date;
}

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  displayedColumns: string[] = ['name', 'personType', 'personalNumber', 'createdAt', 'actions'];
  dataSource = new MatTableDataSource<Client>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private modalService: NgbModal,
    private clientService: ClientService,
    private toastr: ToastrService,
  ) {}

  ngOnInit(): void {
    this.clientService.getAll
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
          this.clientService.delete(id)
            .subscribe(() => {
              this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
              this.clientService.setClients();
            });
        }
      });
  }

}
