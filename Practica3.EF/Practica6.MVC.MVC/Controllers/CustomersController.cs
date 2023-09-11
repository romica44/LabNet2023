using Practica7.WebApi.Entities;
using Practica7.WebApi.Logic;
using Practica7.WebApi.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica7.WebApi.MVC.Controllers
{
    public class CustomersController : Controller
    {
        CustomersLogic customersLogic = new CustomersLogic();

        public ActionResult Index()
        {
            List<Customers> customers = customersLogic.GetAll();

            List<CustomersView> customersViews = customers.Select(s => new CustomersView
            {
                CustomerID = s.CustomerID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                Phone = s.Phone,
            }).ToList();

            return View(customersViews);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomersView customersView)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var customer = new Customers
                {
                    CustomerID = customersView.CustomerID,
                    CompanyName = customersView.CompanyName,
                    ContactName = customersView.ContactName,
                    Phone = customersView.Phone,
                };

                customersLogic.Add(customer);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

    }
}