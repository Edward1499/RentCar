import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { DeleteModalComponent } from 'src/app/shared/components/delete-modal/delete-modal.component';
import { AddModalComponent } from '../components/add-modal/add-modal.component';
import { BrandService } from '../services/brand.service';

interface Brand {
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
export class ListComponent implements OnInit {

  displayedColumns: string[] = ['description', 'isActive', 'createdAt', 'actions'];
  dataSource = new MatTableDataSource<Brand>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private modalService: NgbModal,
    private brandService: BrandService,
    private toastr: ToastrService,
  ) {}

  ngOnInit(): void {
    this.brandService.getAll
      .subscribe(data => {
        this.dataSource.data = data;
      });

  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  open(id?: number) {
    const modalRef = this.modalService.open(AddModalComponent, { ariaLabelledBy: 'modal-basic-title' });
    if (id) {
      modalRef.componentInstance.id = id;
    }
	}

  onRemove(id: number) {
    this.modalService.open(DeleteModalComponent, { ariaLabelledBy: 'modal-basic-title' }).result
      .then(_ => {}
      ,(reason) => {
        if (reason === 'remove') {
          this.brandService.delete(id)
            .subscribe(() => {
              this.toastr.success('Operacion realizada satisfactoriamente!', 'Operacion Exitosa!');
              this.brandService.setBrands();
            });
        }
      });
  }
}
