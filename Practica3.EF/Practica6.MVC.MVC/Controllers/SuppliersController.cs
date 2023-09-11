using Practica7.WebApi.Entities;
using Practica7.WebApi.Logic;
using Practica7.WebApi.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica7.WebApi.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        SuppliersLogic suppliersLogic = new SuppliersLogic();

        public ActionResult Index()
        {
            List<Suppliers> suppliers = suppliersLogic.GetAll();

            List<SuppliersView> suppliersViews = suppliers.Select(s => new SuppliersView
            {
                SupplierID = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                Phone = s.Phone,
            }).ToList();

            return View(suppliersViews);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SuppliersView suppliersViews)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var supplier = new Suppliers
                {
                    CompanyName = suppliersViews.CompanyName,
                    ContactName = suppliersViews.ContactName,
                    Phone = suppliersViews.Phone,
                };

                suppliersLogic.Add(supplier);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

    }
}