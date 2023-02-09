import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ReportModalComponent } from '../../components/report-modal/report-modal.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  constructor(private modalService: NgbModal,) {}

  openReportModal() {
    this.modalService.open(ReportModalComponent, { ariaLabelledBy: 'modal-basic-title', size: 'lg' });
	}

}
