using Practica6.MVC.Entities;
using Practica6.MVC.Logic;
using System;

namespace Practica6.MVC.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool condicion = true;
            while (condicion)
            {
                condicion = MenuOpciones();
            }
        }
        private static bool MenuOpciones()
        {
            Console.Clear();
            Console.WriteLine("------------Menu-----------");
            Console.WriteLine("1-Mostrar Regiones");
            Console.WriteLine("2-Mostrar Productos");
            Console.WriteLine("3-Mostrar Territorios");
            Console.WriteLine("4-Mostrar Empleados");
            Console.WriteLine("5-Mostrar Clientes");
            Console.WriteLine("6-Mostrar Proveedores");
            Console.WriteLine("7-Agregar Producto");
            Console.WriteLine("8-Modificar Producto");
            Console.WriteLine("9-Eliminar Producto");
            Console.WriteLine("10-Agregar Proveedor");
            Console.WriteLine("11-Modificar Proveedor");
            Console.WriteLine("12-Eliminar Proveedor");
            Console.WriteLine("13-Exit\n");
            Console.WriteLine("---------------------------");
            Console.Write("Ingrese una opción:".PadRight(20));

            string opcion = Console.ReadLine();
            switch (opcion)

            {
                case "1":
                    MostrarRegion();
                    return true;
                case "2":
                    MostrarProducto();
                    return true;
                case "3":
                    MostrarTerritorio();
                    return true;
                case "4":
                    MostrarEmpleados();
                    return true;
                case "5":
                    MostrarClientes();
                    return true;
                case "6":
                    MostrarProveedores();
                    return true;
                case "7":
                    AgregarProducto();
                    return true;
                case "8":
                    ModificarProducto();
                    return true;
                case "9":
                    EliminarProducto();
                    return true;
                case "10":
                    AgregarProveedor();
                    return true;
                case "11":
                    ModificarProveedor();
                    return true;
                case "12":
                    EliminarProveedor();
                    return true;
                case "13":
                    return false;
                default:
                    Console.WriteLine("Opción no válida. Presiona una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
            return true;
        }

        public static void MostrarRegion()
        {
            Console.WriteLine("Mostrando Regiones:");
            RegionLogic regionLogic = new RegionLogic();
            foreach (var item in regionLogic.GetAll())
            {
                Console.WriteLine($"{item.RegionID} - {item.RegionDescription}");
            }
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadLine();
        }

        public static void MostrarProducto()
        {
            Console.WriteLine("Mostrando Productos:");
            ProductsLogic productoLogic = new ProductsLogic();
            foreach (var item in productoLogic.GetAll())
            {
                Console.WriteLine($"{item.ProductID} - {item.ProductName}");
            }
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadLine();
        }

        public static void MostrarTerritorio()
        {
            Console.WriteLine("Mostrando Territorios:");
            TerritoriesLogic territoriesLogic = new TerritoriesLogic();
            foreach (var item in territoriesLogic.GetAll())
            {
                Console.WriteLine($"{item.TerritoryID} - {item.TerritoryDescription}");
            }
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadLine();
        }

        public static void MostrarEmpleados()
        {
            Console.WriteLine("Mostrando Empleados:");
            EmployeesLogic employeesLogic = new EmployeesLogic();
            foreach (var item in employeesLogic.GetAll())
            {
                Console.WriteLine($"{item.EmployeeID} - {item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadLine();
        }
        public static void MostrarClientes()
        {
            Console.WriteLine("Mostrando Clientes:");
            CustomersLogic customersLogic = new CustomersLogic();
            foreach (var item in customersLogic.GetAll())
            {
                Console.WriteLine($"{item.CustomerID} - {item.CompanyName} - {item.ContactName} - {item.ContactTitle} - {item.Phone}");
            }
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadLine();
        }
        public static void MostrarProveedores()
        {
            Console.WriteLine("Mostrando Proveedores:");
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            foreach (var item in suppliersLogic.GetAll())
            {
                Console.WriteLine($"{item.CompanyName} - {item.ContactName} - {item.ContactTitle} - {item.Phone}");
            }
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadLine();
        }

        public static void AgregarProducto()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            Console.Write("Nombre: ");
            string nombre = (Console.ReadLine());
            Console.Write("Precio :");
            string precio = (Console.ReadLine());
    

            Products newProduct = new Products
            {
                ProductName = nombre,
                UnitPrice = Decimal.Parse(precio)
            };

            productsLogic.Add(newProduct);
            Console.WriteLine($"El Producto ha sido agregado con el ID: {newProduct.ProductID}. Presiona una tecla para volver al menú...");
            Console.ReadKey();
        }
        public static void ModificarProducto()
        {
            ProductsLogic productsLogic = new ProductsLogic();

            Console.Write("Ingrese el ID del producto que desea modificar: ");
            int id = Int32.Parse(Console.ReadLine());

            var existingProduct = productsLogic.GetProductByID(id);

            if (existingProduct != null)
            {
                Console.WriteLine($"Producto encontrado:\nID: {existingProduct.ProductID}\nNombre: {existingProduct.ProductName}\nPrecio: {existingProduct.UnitPrice}");

                Console.WriteLine("¿Qué campo desea modificar?");
                Console.WriteLine("1 - Nombre");
                Console.WriteLine("2 - Precio");
                Console.Write("Ingrese una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nuevo nombre: ");
                        string nuevoNombre = Console.ReadLine();
                        existingProduct.ProductName = nuevoNombre;
                        break;
                    case "2":
                        Console.Write("Nuevo precio: ");
                        decimal nuevoPrecio = Decimal.Parse(Console.ReadLine());
                        existingProduct.UnitPrice = nuevoPrecio;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        return;
                }

                productsLogic.Update(existingProduct);
                Console.WriteLine("El Producto ha sido modificado. Presiona una tecla para volver al menú...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
        public static void EliminarProducto()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            Console.Write("Ingrese el ID del producto que desea eliminar: ");
            int id = Int32.Parse(Console.ReadLine());

            var productToDelete = productsLogic.GetProductByID(id);

            if (productToDelete != null)
            {
                Console.WriteLine($"Producto encontrado:\nID: {productToDelete.ProductID}\nNombre: {productToDelete.ProductName}\nPrecio: {productToDelete.UnitPrice}");

                Console.WriteLine("¿Está seguro de que desea eliminar este producto?");
                Console.WriteLine("1 - Si");
                Console.WriteLine("2 - No");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        productsLogic.Delete(id);
                        Console.WriteLine("Producto eliminado. Presiona una tecla para volver al menú...");
                        break;
                    case "2":
                        Console.WriteLine("Eliminación cancelada. Presiona una tecla para volver al menú...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }


        public static void AgregarProveedor()
        {
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            Console.Write("Nombre de la compañía: ");
            string nombreCompania = Console.ReadLine();

            Suppliers newSupplier = new Suppliers
            {
                CompanyName = nombreCompania
            };

            suppliersLogic.Add(newSupplier);
            Console.WriteLine($"El Proveedor ha sido agregado con el ID: {newSupplier.SupplierID}. Presiona una tecla para volver al menú...");
            Console.ReadKey();
        }

        public static void ModificarProveedor()
        {
            SuppliersLogic suppliersLogic = new SuppliersLogic();

            Console.Write("Ingrese el ID del proveedor que desea modificar: ");
            int id = Int32.Parse(Console.ReadLine());

            var existingSupplier = suppliersLogic.GetSupplierByID(id);

            if (existingSupplier != null)
            {
                Console.WriteLine($"Proveedor encontrado:\nID: {existingSupplier.SupplierID}\nNombre de la compañía: {existingSupplier.CompanyName}");

                Console.WriteLine("¿Desea modificar el nombre de la compañía? (Sí / No)");
                string respuesta = Console.ReadLine();

                if (respuesta.Trim().ToLower() == "si")
                {
                    Console.Write("Nuevo nombre de la compañía: ");
                    string nuevoNombreCompania = Console.ReadLine();
                    existingSupplier.CompanyName = nuevoNombreCompania;
                    suppliersLogic.Update(existingSupplier);
                    Console.WriteLine("El Proveedor ha sido modificado. Presiona una tecla para volver al menú...");
                }
                else
                {
                    Console.WriteLine("Modificación cancelada. Presiona una tecla para volver al menú...");
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Proveedor no encontrado.");
            }
        }

        public static void EliminarProveedor()
        {
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            Console.Write("Ingrese el ID del proveedor que desea eliminar: ");
            int id = Int32.Parse(Console.ReadLine());

            var supplierToDelete = suppliersLogic.GetSupplierByID(id);

            if (supplierToDelete != null)
            {
                Console.WriteLine($"Proveedor encontrado:\nID: {supplierToDelete.SupplierID}\nNombre de la compañía: {supplierToDelete.CompanyName}");

                Console.WriteLine("¿Está seguro de que desea eliminar este proveedor? (Sí / No)");
                string respuesta = Console.ReadLine();

                if (respuesta.Trim().ToLower() == "si")
                {
                    suppliersLogic.Delete(id);
                    Console.WriteLine("Proveedor eliminado. Presiona una tecla para volver al menú...");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada. Presiona una tecla para volver al menú...");
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Proveedor no encontrado.");
            }
        }

    }

}
