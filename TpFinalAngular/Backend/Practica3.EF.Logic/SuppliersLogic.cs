using Practica7.WebApi.Data;
using Practica7.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica7.WebApi.Logic
{
    public class SuppliersLogic : BaseLogic, IABMLogic<Suppliers>
    {
        public List<Suppliers> GetAll()
        {
            return context.Suppliers.ToList();
        }

        public void Add(Suppliers newSupplier)
        {
            if (string.IsNullOrEmpty(newSupplier.CompanyName))
            {
                throw new ArgumentException("El nombre del proveedor es obligatorio.");
            }

            context.Suppliers.Add(newSupplier);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using (var context = new NorthwindContext())
            {
                var supplierToDelete = context.Suppliers.Find(id);
                if (supplierToDelete != null)
                {
                    // Buscar productos asociados al proveedor
                    var productsWithSupplier = context.Products.Where(p => p.SupplierID == id).ToList();

                    // Eliminar registros relacionados con el proveedor (productos y detalles de pedido)
                    foreach (var product in productsWithSupplier)
                    {
                        var orderDetailsToDelete = context.Order_Details.Where(od => od.ProductID == product.ProductID).ToList();
                        context.Order_Details.RemoveRange(orderDetailsToDelete);
                    }

                    // Eliminar los productos asociados al proveedor
                    context.Products.RemoveRange(productsWithSupplier);

                    // Finalmente, eliminar el proveedor
                    context.Suppliers.Remove(supplierToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("El proveedor no existe.");
                }
            }
        }

        public void Update(Suppliers supplier)
        {
            var supplierUpdate = context.Suppliers.Find(supplier.SupplierID);
            if (supplierUpdate != null)
            {
                supplierUpdate.CompanyName = supplier.CompanyName;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El proveedor no existe.");
            }
        }

        public Suppliers GetSupplierByID(int id)
        {
            return context.Suppliers.FirstOrDefault(supplier => supplier.SupplierID == id);
        }
    }

}
