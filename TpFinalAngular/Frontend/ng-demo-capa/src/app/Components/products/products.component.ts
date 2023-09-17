import { Component } from '@angular/core';
import { SweetAlertContentComponent } from '../sweet-alert-content/sweet-alert-content.component';
import { Product } from '../../models/product';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent {
  selectedProduct: Product | null | undefined;

  showFormModal = false;
  showModal: boolean = false;

  constructor(private modalService: NgbModal) {}

  openSweetAlertModal() {
    const modalRef = this.modalService.open(SweetAlertContentComponent, {
      centered: true,
    });

    console.log(modalRef.componentInstance);
  }
}
