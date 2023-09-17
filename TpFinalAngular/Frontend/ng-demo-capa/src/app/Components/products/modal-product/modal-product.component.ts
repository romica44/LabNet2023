import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { Product } from '../../../models/product';


@Component({
  selector: 'app-modal-product',
  templateUrl: './modal-product.component.html',
  styleUrls: ['./modal-product.component.css']
})
export class ModalProductComponent implements OnInit {
  @Input() product: Product | null | undefined;

  constructor() {}

  ngOnInit(): void {}

}
