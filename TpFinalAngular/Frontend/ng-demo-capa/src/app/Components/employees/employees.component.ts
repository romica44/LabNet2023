import { Component } from '@angular/core';
import { SweetAlertContentComponent } from '../sweet-alert-content/sweet-alert-content.component';
import { Employee } from '../../models/employee';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
})
export class EmployeesComponent {
  selectedEmployee: Employee | null | undefined;
  showFormModal = false;

  constructor(private modalService: NgbModal) {}

  openSweetAlertModal() {
    const modalRef = this.modalService.open(SweetAlertContentComponent, {
      centered: true,
    });

    console.log(modalRef.componentInstance);
  }
}
