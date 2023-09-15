using Practica7.WebApi.Entities;
using Practica7.WebApi.Logic;
using Practica7.WebApi.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Practica7.WebApi.Api.Controllers
{
    /// <summary>
    /// Controlador para la gestión de productos.
    /// </summary>
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
       
        private readonly ProductsLogic _productsLogic;


        public ProductsController()
        {
            _productsLogic = new ProductsLogic();
        }

        /// <summary>
        /// Obtiene la lista de todos los productos.
        /// </summary>
        /// <returns>Una lista de productos.</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                List<Products> products = _productsLogic.GetAll();

                List<ProductsView> productsViews = products.Select(s => new ProductsView
                {
                    ProductID = s.ProductID,
                    ProductName = s.ProductName,
                    SupplierID = s.SupplierID,
                    CategoryID = s.CategoryID,
                    QuantityPerUnit = s.QuantityPerUnit,
                    UnitPrice = (decimal)s.UnitPrice,
                    UnitsInStock = s.UnitsInStock,
                    UnitsOnOrder = s.UnitsOnOrder,
                }).ToList();

                return Ok(productsViews);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto.</param>
        /// <returns>Los datos del producto o un error si no se encuentra.</returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            try
            {
                Products product = _productsLogic.GetProductByID(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="product">Los datos del nuevo producto.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateProduct(Products product)
        {
            try
            {
                _productsLogic.Add(product);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Actualiza los datos de un producto.
        /// </summary>
        /// <param name="id">El ID del producto a actualizar.</param>
        /// <param name="product">Los datos actualizados del producto.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateProduct(int id, Products product)
        {
            try
            {
                product.ProductID = id;
                _productsLogic.Update(product);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                _productsLogic.Delete(id);
                return Ok(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
