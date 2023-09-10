using Practica6.MVC.Entities;
using Practica6.MVC.Logic;
using Practica6.MVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica6.MVC.MVC.Controllers
{
    public class ProductsController : Controller
    {
        ProductsLogic productsLogic = new ProductsLogic();

        public ActionResult Index()
        {
            List<Products> products = productsLogic.GetAll();

            List<ProductsView> productsViews = products.Select(s => new ProductsView
            {
                ProductID = s.ProductID,
                ProductName = s.ProductName,
                UnitPrice = (decimal)s.UnitPrice,
            }).ToList();

            return View(productsViews);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductsView productsView)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var product = new Products
                {
                    ProductName = productsView.ProductName,
                    UnitPrice = productsView.UnitPrice,
                };

                productsLogic.Add(product);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                Products product = productsLogic.GetProductByID(id);
                ProductsView productsView = new ProductsView
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    UnitPrice = (decimal)product.UnitPrice,
                };

                return View(productsView);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(ProductsView productsView)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var product = new Products
                {
                    ProductID = productsView.ProductID,
                    ProductName = productsView.ProductName,
                    UnitPrice = productsView.UnitPrice,
                };

                productsLogic.Update(product);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                productsLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}