import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConnectionDbService } from '../../../services/connection-db.service';
import { ModalProductComponent } from '../modal-product/modal-product.component';
import { Product } from '../../../models/product';
import Swal from 'sweetalert2';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-table-product',
  templateUrl: './table-product.component.html',
  styleUrls: ['./table-product.component.css'],
})
export class TableProductComponent {
  formProduct!: FormGroup;
  selectedProduct: Product | null | undefined;
  id!: number;

  public productList: Array<Product> = [];
  constructor(
    private readonly fb: FormBuilder,
    private connectionDbService: ConnectionDbService,
    private modalService: NgbModal
  ) {}

  openSweetAlertModal(product: Product) {
    const modalRef = this.modalService.open(ModalProductComponent, {
      centered: true,
    });
    modalRef.componentInstance.product = product;
  }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.connectionDbService.getAllProducts().subscribe((res) => {
      this.productList = res;
      console.log(this.productList);
    });
  }

  deleteProduct(productId: any) {
    Swal.fire({
      title: '¿Estás seguro de eliminar este producto?',
      text: 'Esta acción no se puede deshacer.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí, eliminar',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.connectionDbService.deleteProduct(productId).subscribe((res) => {
          this.getProducts();
          Swal.fire('Éxito', 'Producto eliminado exitosamente.', 'success');
        });
      } else {
        console.log('Eliminación cancelada');
      }
    });
  }

  updateProduct(product: Product) {
    this.selectedProduct = product;
    this.connectionDbService.sendProduct(product);
  }
}
