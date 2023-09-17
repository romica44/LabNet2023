import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { Product } from '../models/product';
import { environment } from '../../../src/enviroments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/internal/Subject';
@Injectable({
  providedIn: 'root',
})
export class ConnectionDbService {
  private readonly apiBaseUrl: string = environment.apiBaseUrl;

  // Define las URL de los diferentes endpoints
  private readonly employeesEndpoint: string = 'api/employees';
  private readonly productsEndpoint: string = 'api/products';

  // Observables para emitir datos
  private emitEmployee = new Subject<Employee>();
  emitEmployee$ = this.emitEmployee.asObservable();

  private emitProduct = new Subject<Product>();
  emitProduct$ = this.emitProduct.asObservable();

  constructor(private http: HttpClient) {}

  // Función para enviar un objeto Employee
  public sendEmployee(employee: Employee) {
    this.emitEmployee.next(employee);
  }

  // Función para obtener todos los empleados
  public getAllEmployees(): Observable<Employee[]> {
    const url = `${this.apiBaseUrl}/${this.employeesEndpoint}`;
    return this.http.get<Employee[]>(url);
  }

  public getEmployeeById(id: number): Observable<Employee> {
    const url = `${this.apiBaseUrl}/${this.employeesEndpoint}/${id}`;
    return this.http.get<Employee>(url);
  }
  
  // Función para agregar un nuevo empleado
  public addEmployee(employee: Employee): Observable<any> {
    const url = `${this.apiBaseUrl}/${this.employeesEndpoint}`;
    return this.http.post(url, employee);
  }

  // Función para actualizar un empleado
  public updateEmployee(employee: Employee): Observable<any> {
    const updatedData = {
      FirstName: employee.FirstName,
      LastName: employee.LastName,
      Title: employee.Title,
    }
    console.log(updatedData)
    const url = `${this.apiBaseUrl}/${this.employeesEndpoint}/${employee.EmployeeID}`;
    return this.http.put(url, updatedData);
  }

  //Función para eliminar un empleado
  public deleteEmployee(id: number): Observable<any> {
    const url = `${this.apiBaseUrl}/${this.employeesEndpoint}/${id}`;
    return this.http.delete(url);
  }

  public sendProduct(product: Product) {
    this.emitProduct.next(product);
  }

  // Función para obtener todos los productos
  public getAllProducts(): Observable<Product[]> {
    const url = `${this.apiBaseUrl}/${this.productsEndpoint}`;
    return this.http.get<Product[]>(url);
  }

  public getProductById(id: number): Observable<Product> {
    const url = `${this.apiBaseUrl}/${this.employeesEndpoint}/${id}`;
    return this.http.get<Product>(url);
  }

  // Función para agregar un nuevo producto
  public addProduct(product: Product): Observable<any> {
    const url = `${this.apiBaseUrl}/${this.productsEndpoint}`;
    return this.http.post(url, product);
  }

  // Función para actualizar un producto
  public updateProduct(product: Product): Observable<any> {
    const url = `${this.apiBaseUrl}/${this.productsEndpoint}/${product.ProductID}`;
    return this.http.put(url, product);
  }

  //Función para eliminar un producto
  public deleteProduct(id: number): Observable<any> {
    const url = `${this.apiBaseUrl}/${this.productsEndpoint}/${id}`;
    return this.http.delete(url);
  }
}
