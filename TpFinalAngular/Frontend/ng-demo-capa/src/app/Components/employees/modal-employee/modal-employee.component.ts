import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { Employee } from '../../../models/employee';

@Component({
  selector: 'app-modal-employee',
  templateUrl: './modal-employee.component.html',
  styleUrls: ['./modal-employee.component.css']
})
export class ModalEmployeeComponent implements OnInit{
  @Input() employee: Employee | null | undefined;

  constructor() {}

  ngOnInit(): void {}
}
