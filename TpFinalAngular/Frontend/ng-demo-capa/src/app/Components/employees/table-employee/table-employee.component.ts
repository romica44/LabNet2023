import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConnectionDbService } from '../../../services/connection-db.service';
import { SweetAlertContentComponent } from '../../sweet-alert-content/sweet-alert-content.component';
import { Employee } from '../../../models/employee';
import Swal from 'sweetalert2';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-table-employee',
  templateUrl: './table-employee.component.html',
  styleUrls: ['./table-employee.component.css'],
})
export class TableEmployeeComponent implements OnInit {
  formEmployee!: FormGroup;
  selectedEmployee: Employee | null = null;
  id!: number;

  public employeeList: Array<Employee> = [];
  constructor(
    private readonly fb: FormBuilder,
    private connectionDbService: ConnectionDbService,
    private modalService: NgbModal
  ) {}

  openSweetAlertModal(employee: Employee) {
    const modalRef = this.modalService.open(SweetAlertContentComponent, {
      centered: true,
    });
    modalRef.componentInstance.employee = employee;
  }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees() {
    this.connectionDbService.getAllEmployees().subscribe((res) => {
      this.employeeList = res;
      console.log(this.employeeList);
    });
  }

  deleteEmployee(employeeId: any) {
    Swal.fire({
      title: '¿Estás seguro de eliminar este empleado?',
      text: 'Esta acción no se puede deshacer.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí, eliminar',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.connectionDbService.deleteEmployee(employeeId).subscribe((res) => {
          this.getEmployees();
          Swal.fire('Éxito', 'Empleado eliminado exitosamente.', 'success');
        });
      } else {
        console.log('Eliminación cancelada');
      }
    });
  }

  updateEmployee(employee: Employee) {
    this.selectedEmployee = employee;
    this.connectionDbService.sendEmployee(employee);
  }
}
