using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Practica4.Linq.Logic;

namespace Practica4.Linq.UI
{
    class Program
    {
        private static object allProducts;

        static void Main(string[] args)
        {
            bool condition = true;
            while (condition)
            {
                condition = MenuOptions();
            }
        }

        private static bool MenuOptions()
        {
            Console.Clear();
            Console.WriteLine("------------ Menu -----------");
            Console.WriteLine("1. Mostrar el objeto Clientes");
            Console.WriteLine("2. Listar todos los Productos sin stock");
            Console.WriteLine("3. Listar toodos los Productos que tienen stock y más de 3 por unidad");
            Console.WriteLine("4. Listar todos los Clientes de la Región WA");
            Console.WriteLine("5. Mostrar el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            Console.WriteLine("6. mostrar los nombres de los Clientes en Mayúscula y Minúscula");
            Console.WriteLine("7. Mostrar datos de las tablas de Clientes cuya región sea WA y Ordenes relacionadas con fecha de orden sea mayor a 1/1/1997");
            Console.WriteLine("8. Mostrar los primeros 3 Clientes de la Región WA");
            Console.WriteLine("9. Listar todos los Productos ordenados por nombre");
            Console.WriteLine("10. Listar los productos ordenados por unit in stock de mayor a menor");
            Console.WriteLine("11. Mostrar las distintas categorías asociadas a los productos");
            Console.WriteLine("12. Mostrar el primer elemento de una lista de productos");
            Console.WriteLine("13. Listar los Clientes con la cantidad de órdenes asociadas");
            Console.WriteLine("0. Salir\n");
            Console.WriteLine("-----------------------------");
            Console.Write("Ingrese una opción: ".PadRight(20));

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ExecuteQuery1(1, 10);
                    return true;
                case "2":
                    ExecuteQuery2();
                    return true;
                case "3":
                    ExecuteQuery3();
                    return true;
                case "4":
                    ExecuteQuery4();
                    return true;
                case "5":
                    ExecuteQuery5();
                    return true;
                case "6":
                    ExecuteQuery6();
                    return true;
                case "7":
                    ExecuteQuery7();
                    return true;
                case "8":
                    ExecuteQuery8();
                    return true;
                case "9":
                    ExecuteQuery9();
                    return true;
                case "10":
                    ExecuteQuery10();
                    return true;
                case "11":
                    ExecuteQuery11();
                    return true;
                case "12":
                    ExecuteQuery12();
                    return true;
                case "13":
                    ExecuteQuery13();
                    return true;
                case "0":
                    return false;
                default:
                    Console.WriteLine("Opción no válida. Presiona una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
            return true;
        }

        // Métodos para ejecutar las consultas

        private static void ExecuteQuery1(int pageNumber, int pageSize)
        {
            Console.Clear();
            Console.WriteLine("Mostrando todos los clientes:");

            CustomersLogic customersLogic = new CustomersLogic();
            IEnumerable<Entities.Customers> allCustomers = customersLogic.GetAll();

            // Calcular el índice de inicio para la paginación
            int startIndex = (pageNumber - 1) * pageSize;

            // Query sintax con paginación
            var query = allCustomers.Skip(startIndex).Take(pageSize);

            foreach (var customerToDisplay in query)
            {
                Console.WriteLine($"ID: {customerToDisplay.CustomerID}");
                Console.WriteLine($"Nombre de la empresa: {customerToDisplay.CompanyName}");
                Console.WriteLine($"Nombre de contacto: {customerToDisplay.ContactName}");
                Console.WriteLine($"Título de contacto: {customerToDisplay.ContactTitle}");
                Console.WriteLine($"Dirección: {customerToDisplay.Address}");
                Console.WriteLine($"Ciudad: {customerToDisplay.City}");
                Console.WriteLine($"Región: {customerToDisplay.Region}");
                Console.WriteLine($"Código Postal: {customerToDisplay.PostalCode}");
                Console.WriteLine($"País: {customerToDisplay.Country}");
                Console.WriteLine($"Teléfono: {customerToDisplay.Phone}");
                Console.WriteLine($"Fax: {customerToDisplay.Fax}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery2()
        {
            Console.Clear();
            Console.WriteLine("Mostrando detalles de Productos sin stock:");

            ProductsLogic productsLogic = new ProductsLogic();
            IEnumerable<Entities.Products> allProducts = productsLogic.GetAll();

            // Query Method
            var query = allProducts
                .Where(product => product.UnitsInStock == 0)
                .Select(product => new
                {
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice
                })
                .ToList();

            foreach (var product in query)
            {
                Console.WriteLine($"Nombre del producto: {product.ProductName}");
                Console.WriteLine($"Precio unitario: {product.UnitPrice}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }
        private static void ExecuteQuery3()
        {
            Console.Clear();
            Console.WriteLine("Mostrando detalles de Productos que poseen mas de 3 unidades de stock:");

            ProductsLogic productsLogic = new ProductsLogic();
            var allProducts = productsLogic.GetAll();

            //Query Method
            var query = allProducts
                .Where(product => product.UnitsInStock > 0 && QuantityPerUnitContainsMoreThanThree(product.QuantityPerUnit))
                .Select(product => new
                {
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    QuantityPerUnit = product.QuantityPerUnit
                })
                .ToList();

            foreach (var product in query)
            {
                Console.WriteLine($"Nombre del producto: {product.ProductName}");
                Console.WriteLine($"Precio unitario: {product.UnitPrice}");
                Console.WriteLine($"Cantidad Por unidad: {product.QuantityPerUnit}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery4()
        {
            Console.Clear();
            Console.WriteLine("Mostrando todos los clientes con Región WA:");

            CustomersLogic customersLogic = new CustomersLogic();
            IEnumerable<Entities.Customers> allCustomers = customersLogic.GetAll();

            // Query sintax
            var query = from customer in allCustomers
                        where customer.Region == "WA"
                        select customer;

            foreach (var customerToDisplay in query)
            {
                Console.WriteLine($"ID: {customerToDisplay.CustomerID}");
                Console.WriteLine($"Nombre de la empresa: {customerToDisplay.CompanyName}");
                Console.WriteLine($"Nombre de contacto: {customerToDisplay.ContactName}");
                Console.WriteLine($"Título de contacto: {customerToDisplay.ContactTitle}");
                Console.WriteLine($"Dirección: {customerToDisplay.Address}");
                Console.WriteLine($"Ciudad: {customerToDisplay.City}");
                Console.WriteLine($"Región: {customerToDisplay.Region}");
                Console.WriteLine($"Código Postal: {customerToDisplay.PostalCode}");
                Console.WriteLine($"País: {customerToDisplay.Country}");
                Console.WriteLine($"Teléfono: {customerToDisplay.Phone}");
                Console.WriteLine($"Fax: {customerToDisplay.Fax}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery5()
        {
            Console.Clear();
            Console.WriteLine("Mostrando detalles del producto con ID 789:");

            ProductsLogic productsLogic = new ProductsLogic();
            IEnumerable<Entities.Products> allProducts = productsLogic.GetAll();

            //Query Method
            var productToDisplay = allProducts.FirstOrDefault(product => product.ProductID == 789);

            if (productToDisplay != null)
            {
                Console.WriteLine($"ID del producto: {productToDisplay.ProductID}");
                Console.WriteLine($"Nombre del producto: {productToDisplay.ProductName}");
                Console.WriteLine($"Precio unitario: {productToDisplay.UnitPrice}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery6()
        {
            Console.Clear();
            Console.WriteLine("Mostrando nombres de clientes en mayúscula y minúscula:");

            CustomersLogic customersLogic = new CustomersLogic();
            IEnumerable<Entities.Customers> allCustomers = customersLogic.GetAll();

            //Query syntax
            var query = from customer in allCustomers
                        select new
                        {
                            Mayuscula = customer.ContactName.ToUpper(),
                            Minuscula = customer.ContactName.ToLower()
                        };

            foreach (var customerNames in query)
            {
                Console.WriteLine($"Mayúscula: {customerNames.Mayuscula}");
                Console.WriteLine($"Minúscula: {customerNames.Minuscula}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery7()
        {
            Console.Clear();
            Console.WriteLine("Mostrando Clientes con Región WA y órdenes asociadas con fecha mayor a  1/1/1997: ");

            CustomersLogic customersLogic = new CustomersLogic();
            OrdersLogic ordersLogic = new OrdersLogic();

            IEnumerable<Entities.Customers> customers = customersLogic.GetAll();
            IEnumerable<Entities.Orders> orders = ordersLogic.GetAll();

            //Query method
            var query = customers
                .Join(
                    orders,
                    customer => customer.CustomerID,
                    order => order.CustomerID,
                    (customer, order) => new
                    {
                        Customer = customer,
                        Order = order
                    })
                .Where(result =>
                    result.Customer.Region == "WA" &&
                    result.Order.OrderDate > new DateTime(1997, 1, 1))
                .Select(result => new
                {
                    CustomerName = result.Customer.ContactName,
                    OrderDate = result.Order.OrderDate
                });

            foreach (var result in query)
            {
                Console.WriteLine($"Nombre del Cliente: {result.CustomerName}");
                Console.WriteLine($"Fecha de la Orden: {result.OrderDate}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery8()
        {
            Console.Clear();
            Console.WriteLine("Mostrando los primeros 3 clientes de la Región WA:");

            CustomersLogic customersLogic = new CustomersLogic();
            IEnumerable<Entities.Customers> allCustomers = customersLogic.GetAll();

            // Query Syntax
            var query = (from customer in allCustomers
                         where customer.Region == "WA"
                         select customer)
                        .Take(3);

            foreach (var customerToDisplay in query)
            {
                Console.WriteLine($"ID: {customerToDisplay.CustomerID}");
                Console.WriteLine($"Nombre de la empresa: {customerToDisplay.CompanyName}");
                Console.WriteLine($"Nombre de contacto: {customerToDisplay.ContactName}");
                Console.WriteLine($"Título de contacto: {customerToDisplay.ContactTitle}");
                Console.WriteLine($"Dirección: {customerToDisplay.Address}");
                Console.WriteLine($"Ciudad: {customerToDisplay.City}");
                Console.WriteLine($"Región: {customerToDisplay.Region}");
                Console.WriteLine($"Código Postal: {customerToDisplay.PostalCode}");
                Console.WriteLine($"País: {customerToDisplay.Country}");
                Console.WriteLine($"Teléfono: {customerToDisplay.Phone}");
                Console.WriteLine($"Fax: {customerToDisplay.Fax}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery9()
        {
            Console.Clear();
            Console.WriteLine("Listando todos los productos ordenados por nombre:");

            ProductsLogic productsLogic = new ProductsLogic();
            IEnumerable<Entities.Products> allProducts = productsLogic.GetAll();

            // Query Method
            var query = allProducts.OrderBy(product => product.ProductName);

            foreach (var product in query)
            {
                Console.WriteLine($"Nombre del producto: {product.ProductName}");
                Console.WriteLine($"Precio unitario: {product.UnitPrice}");
                Console.WriteLine($"Unidades en stock: {product.UnitsInStock}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery10()
        {
            Console.Clear();
            Console.WriteLine("Listando los productos ordenados por UnitInStock de mayor a menor:");

            ProductsLogic productsLogic = new ProductsLogic();
            IEnumerable<Entities.Products> allProducts = productsLogic.GetAll();

            // Query Syntax
            var query = from product in allProducts
                        orderby product.UnitsInStock descending
                        select product;

            foreach (var product in query)
            {
                Console.WriteLine($"Nombre del producto: {product.ProductName}");
                Console.WriteLine($"Precio unitario: {product.UnitPrice}");
                Console.WriteLine($"Unidades en stock: {product.UnitsInStock}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery11()
        {
            Console.Clear();
            Console.WriteLine("Mostrando las distintas categorías asociadas a los productos:");

            ProductsLogic productsLogic = new ProductsLogic();
            CategoriesLogic categoriesLogic = new CategoriesLogic();

            IEnumerable<Entities.Products> allProducts = productsLogic.GetAll();
            IEnumerable<Entities.Categories> allCategories = categoriesLogic.GetAll();

            // Query Method
            var distinctCategories = allProducts
                .Join(allCategories, product => product.CategoryID, category => category.CategoryID, (product, category) => category.CategoryName)
                .Distinct()
                .ToList();

            foreach (var category in distinctCategories)
            {
                Console.WriteLine($"Categoría: {category}");
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery12()
        {
            Console.Clear();
            Console.WriteLine("Mostrando el primer elemento de la lista de Productos:");

            ProductsLogic productsLogic = new ProductsLogic();
            IEnumerable<Entities.Products> allProducts = productsLogic.GetAll();

            //Query sintax
            var firstProduct = (from product in allProducts
                                select product).FirstOrDefault();

            if (firstProduct != null)
            {
                Console.WriteLine($"Nombre del producto: {firstProduct.ProductName}");
                Console.WriteLine($"Precio unitario: {firstProduct.UnitPrice}");
            }
            else
            {
                Console.WriteLine("La lista de productos está vacía.");
            }


            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }

        private static void ExecuteQuery13()
        {
            Console.Clear();
            Console.WriteLine("Mostrando los Clientes con la cantidad de ordenes asociadas:");

            CustomersLogic customersLogic = new CustomersLogic();
            OrdersLogic ordersLogic = new OrdersLogic();

            IEnumerable<Entities.Customers> allCustomers = customersLogic.GetAll();
            IEnumerable<Entities.Orders> allOrders = ordersLogic.GetAll();
            
            //Query sintax
            var query = from customer in allCustomers
                        join order in allOrders on customer.CustomerID equals order.CustomerID
                        group customer by customer.CustomerID into g
                        select new
                        {
                            CustomerName = g.First().CompanyName,
                            OrderCount = g.Count()
                        };

            foreach (var result in query)
            {
                Console.WriteLine($"Nombre del cliente: {result.CustomerName}");
                Console.WriteLine($"Cantidad de órdenes: {result.OrderCount}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para volver al menú.");
            Console.ReadLine();
        }




        private static bool QuantityPerUnitContainsMoreThanThree(string quantityPerUnit)
        {
            List<string> parts = quantityPerUnit.Split('-').Select(part => part.Trim()).ToList();

            if (parts.Count >= 1 && int.TryParse(parts[0], out int num))
            {
                return num > 3;
            }
            return false;
        }
    }
}