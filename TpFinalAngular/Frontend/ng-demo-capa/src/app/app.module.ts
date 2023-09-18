import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { FooterComponent } from './Components/footer/footer.component';
import { EmployeesComponent } from './Components/employees/employees.component';
import { ProductsComponent } from './Components/products/products.component';
import { HomeComponent } from './Components/home/home.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TableEmployeeComponent } from './Components/employees/table-employee/table-employee.component';
import { FormEmployeeComponent } from './Components/employees/form-employee/form-employee.component';
import { TableProductComponent } from './Components/products/table-product/table-product.component';
import { FormProductComponent } from './Components/products/form-product/form-product.component';
import { ModalEmployeeComponent } from './Components/employees/modal-employee/modal-employee.component';
import { ModalProductComponent } from './Components/products/modal-product/modal-product.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import {MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    EmployeesComponent,
    ProductsComponent,
    HomeComponent,
    TableEmployeeComponent,
    FormEmployeeComponent,
    TableProductComponent,
    FormProductComponent,
    ModalEmployeeComponent,
    ModalProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
