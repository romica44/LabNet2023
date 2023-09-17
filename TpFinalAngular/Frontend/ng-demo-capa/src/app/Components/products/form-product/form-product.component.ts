import { Component, Input, OnInit, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConnectionDbService } from 'src/app/services/connection-db.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-form-product',
  templateUrl: './form-product.component.html',
  styleUrls: ['./form-product.component.css'],
})
export class FormProductComponent implements OnInit {
  @Input() product: Product | null | undefined;
  formProduct!: FormGroup;
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
    this.formProduct = this.fb.group({
      ProductName: ['', [Validators.required, Validators.maxLength(40)]],
      UnitPrice: ['', [Validators.required, Validators.maxLength(25)]],
    });

    if (this.product) {
      this.formProduct.patchValue(this.product);
      this.edit = 'Update';
    }
  }

  get forms() {
    return this.formProduct.controls;
  }

  saveProduct(): void {
    const productData = this.formProduct.value;
    if (this.product) {
      productData.ProductID = this.product.ProductID;
      this.connectionDbService
        .updateProduct(this.formProduct.value)
        .subscribe((res) => {
          this.formProduct.reset();
          console.log(res, 'El Producto fue actualizado');
        });
    } else {
      this.connectionDbService.addProduct(productData).subscribe((res) => {
        this.formProduct.reset();
        console.log(res, 'Se agregó el producto');
      });
    }
  }

  cleanForm(): void {
    this.formProduct.reset();
    this.edit = 'Save';
  }
}
