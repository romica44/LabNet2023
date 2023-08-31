using Practica3.EF.Data;
using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
        public class ProductsLogic : BaseLogic,IABMLogic<Products>
        {
        public void Add(Products element)
            {
            if (string.IsNullOrEmpty(element.ProductName))
            {
                throw new ArgumentException("El nombre del producto es obligatorio.");
            }

            if (element.UnitPrice <= 0)
            {
                throw new ArgumentException("El precio del producto debe ser mayor que cero.");
            }

            context.Products.Add(element);
            context.SaveChanges();
            }

            public void Delete(int id)
            {
            using (var context = new NorthwindContext())
            {
                var productToDelete = context.Products.Find(id);

                if (productToDelete != null)
                {
                    // Buscar detalles de pedido asociados al producto
                    var orderDetailsToDelete = context.Order_Details.Where(od => od.ProductID == id).ToList();

                    // Eliminar los detalles de pedido relacionados con el producto
                    context.Order_Details.RemoveRange(orderDetailsToDelete);

                    // Finalmente, eliminar el producto
                    context.Products.Remove(productToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("El producto no existe.");
                }
            }
        }

            public List<Products> GetAll()
            {
                return context.Products.ToList();
            }

        public Products GetProductByID(int id)
        {
            return context.Products.FirstOrDefault(product => product.ProductID == id);
        }

        public void Update(Products element)
            {
                var existingProduct = context.Products.Find(element.ProductID);

                if (existingProduct != null)
                {
                    existingProduct.ProductName = element.ProductName;
                    existingProduct.UnitPrice = element.UnitPrice;

                    context.SaveChanges();
                }
                else
                {
                throw new ArgumentException("El producto no existe.");
                }
            }
        }
    }
