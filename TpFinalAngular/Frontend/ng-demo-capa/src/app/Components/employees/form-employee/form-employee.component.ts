import { Component, Input, OnInit, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../../../models/employee';
import { ConnectionDbService } from '../../../services/connection-db.service';

@Component({
  selector: 'app-form-employee',
  templateUrl: './form-employee.component.html',
  styleUrls: ['./form-employee.component.css'],
})
export class FormEmployeeComponent implements OnInit {
  @Input() employee: Employee | null | undefined;
  formEmployee!: FormGroup;
  edit: string = 'Save';

  constructor(
    private readonly fb: FormBuilder,
    public connectionDbService: ConnectionDbService,
    private el: ElementRef
  ) {}

  getNativeElement(): HTMLElement {
    return this.el.nativeElement;
  }

  ngOnInit(): void {
    this.formEmployee = this.fb.group({
      FirstName: ['', [Validators.required, Validators.maxLength(25)]],
      LastName: ['', [Validators.required, Validators.maxLength(25)]],
      Title: ['', [Validators.required, Validators.maxLength(24)]],
    });

    // Verifica si hay un empleado proporcionado para determinar si es una edición
    if (this.employee) {
      this.formEmployee.patchValue(this.employee);
      this.edit = 'Update';
    }
  }

  get forms() {
    return this.formEmployee.controls;
  }
  

  saveEmployee(): void {
    const employeeData = this.formEmployee.value;

    if (this.employee) {
      employeeData.EmployeeID = this.employee.EmployeeID;

      this.connectionDbService.updateEmployee(employeeData).subscribe((res) => {
        this.formEmployee.reset();
        console.log('El empleado fue actualizado'); 
      });
    } else {
      this.connectionDbService.addEmployee(employeeData).subscribe((res) => {
        this.formEmployee.reset();
        console.log('Se agregó el empleado');
      });
    }
  }



  cleanForm(): void {
    this.formEmployee.reset();
    this.edit = 'Save';
  }
}
