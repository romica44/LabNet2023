import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { Employee } from '../../models/employee';
import { Product } from '../../models/product';

@Component({
  selector: 'app-sweet-alert-content',
  templateUrl: './sweet-alert-content.component.html',
  styleUrls: ['./sweet-alert-content.component.css'],
})
export class SweetAlertContentComponent implements OnInit {
  @Input() employee: Employee | null | undefined;
  @Input() product: Product | null | undefined;

  constructor() {}

  ngOnInit(): void {}
}
