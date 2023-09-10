using Practica6.MVC.Entities;
using Practica6.MVC.Logic;
using Practica6.MVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica6.MVC.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesLogic employeesLogic = new EmployeesLogic();

        private readonly EmployeesLogic _employeesLogic;

        public EmployeesController()
        {
            _employeesLogic = new EmployeesLogic();
        }
        // GET: Employees
        public ActionResult Index()
        {
            List<Employees> employees = employeesLogic.GetAll();

            List<EmployeesView> employeesViews = employees.Select(s => new EmployeesView
            {
                EmployeeID = s.EmployeeID,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Title = s.Title,
            }).ToList();

            return View(employeesViews);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeesView employeesView)
        {
            if (!ModelState.IsValid)
                return PartialView("Create", employeesView);

            try
            {
                var employee = new Employees
                {
                    FirstName = employeesView.FirstName,
                    LastName = employeesView.LastName,
                    Title = employeesView.Title,
                };

                employeesLogic.Add(employee);

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
                Employees employee = employeesLogic.GetEmployeeByID(id);
                EmployeesView employeesView = new EmployeesView
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                };

                return PartialView("Update", employeesView);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public EmployeesLogic GetEmployeesLogic()
        {
            return employeesLogic;
        }

        [HttpPost]
        public ActionResult Update(EmployeesView employeesView, EmployeesLogic employeesLogic)
        {
            if (!ModelState.IsValid)
                return PartialView("Update", employeesView);

            try
            {
                var employee = new Employees
                {
                    EmployeeID = employeesView.EmployeeID,
                    FirstName = employeesView.FirstName,
                    LastName = employeesView.LastName,
                    Title = employeesView.Title,
                };
                _employeesLogic.Update(employee);

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
                employeesLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int employeeID)
        {
            try
            {
                employeesLogic.Delete(employeeID);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
    }
}