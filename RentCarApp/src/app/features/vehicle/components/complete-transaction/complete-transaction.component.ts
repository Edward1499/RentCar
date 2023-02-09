import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-complete-transaction',
  templateUrl: './complete-transaction.component.html',
  styleUrls: ['./complete-transaction.component.scss']
})
export class CompleteTransactionComponent {

  constructor(
    private modalService: NgbModal,
  ) { }

  onClose() {
    this.modalService.dismissAll();
  }

  onClickRemove() {
    this.modalService.dismissAll('complete');
  }

}
