import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConnectionDbService } from '../../../services/connection-db.service';
import { ModalEmployeeComponent } from '../modal-employee/modal-employee.component';
import { Employee } from '../../../models/employee';
import Swal from 'sweetalert2';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-table-employee',
  templateUrl: './table-employee.component.html',
  styleUrls: ['./table-employee.component.css'],
})
export class TableEmployeeComponent implements OnInit, AfterViewInit {
  formEmployee!: FormGroup;
  selectedEmployee: Employee | null = null;
  id!: number;
  displayedColumns: string[] = ['id', 'Nombre', 'Apellido', 'Puesto Laboral', 'Acciones'];

  applyFilter(event: any) {
    const filterValue = (event.target as HTMLInputElement).value; 
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  dataSource: MatTableDataSource<Employee> = new MatTableDataSource();
  isLoading: boolean = true;

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }
  public employeeList: Array<Employee> = [];
  constructor(
    private readonly fb: FormBuilder,
    private connectionDbService: ConnectionDbService,
    private modalService: NgbModal
  ) {}

  openSweetAlertModal(employee: Employee) {
    const modalRef = this.modalService.open(ModalEmployeeComponent, {
      centered: true,
    });
    modalRef.componentInstance.employee = employee;
  }

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees() {
    this.isLoading = true; 
    this.connectionDbService.getAllEmployees().subscribe((res) => {
      this.employeeList = res;
      this.dataSource = new MatTableDataSource(this.employeeList);
      this.dataSource.paginator = this.paginator;
      this.isLoading = false;
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
          this.loadEmployees();
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
