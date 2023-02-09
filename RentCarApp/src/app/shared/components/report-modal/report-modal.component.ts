import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import swal from 'sweetalert2';
import { ReportService } from '../../services/report.service';

@Component({
  selector: 'app-report-modal',
  templateUrl: './report-modal.component.html',
  styleUrls: ['./report-modal.component.scss']
})
export class ReportModalComponent implements OnInit {

  form: FormGroup = this.fb.group({
    startDate: [null, [Validators.required]],
    endDate: [null, [Validators.required]],
  });

  constructor(
    private modalService: NgbModal,
    private fb: FormBuilder,
    private reportService: ReportService
  ) {}

  ngOnInit(): void {
    this.form.get('startDate')?.valueChanges
      .subscribe(() => {
        this.onChangeDate();
      });

    this.form.get('endDate')?.valueChanges
      .subscribe(() => {
        this.onChangeDate();
      });
  }

  onChangeDate() {
    if (!this.form.get('startDate')?.value || !this.form.get('endDate')?.value) {
      return;
    }

    const { year: startDateYear, month: startDateMonth, day: startDateDay } = this.form.get('startDate')?.value;
    const { year: endDateYear, month: endDateMonth, day: endDateDay } = this.form.get('endDate')?.value;

    const startDate: any = new Date(`${startDateYear}-${startDateMonth}-${startDateDay}`);
    const endDate: any = new Date(`${endDateYear}-${endDateMonth}-${endDateDay}`);

    if (endDate < startDate) {
      this.form.get('endDate')?.setValue(null);
      swal.fire({
        icon: 'error',
        title: 'Error...',
        text: 'La fecha de fin no puede ser menor a la fecha de inicio!',
      });
      return;
    }
  }

  onClose() {
    this.modalService.dismissAll();
  }

  generate() {
    const { year: startDateYear, month: startDateMonth, day: startDateDay } = this.form.get('startDate')?.value;
    const { year: endDateYear, month: endDateMonth, day: endDateDay } = this.form.get('endDate')?.value;

    const request = {
      startDate: new Date(`${startDateYear}-${startDateMonth}-${startDateDay}`),
      endDate: new Date(`${endDateYear}-${endDateMonth}-${endDateDay}`)
    }

    this.reportService.generate(request)
      .subscribe((report) => {
        window.open(report, '_blank');
        this.modalService.dismissAll();
    });
  }

}
