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
    /// Controlador para la gestión de Empleados.
    /// </summary>
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        private readonly EmployeesLogic _employeesLogic;

        public EmployeesController()
        {
            _employeesLogic = new EmployeesLogic();
        }
        /// <summary>
        /// Obtiene la lista de empleados.
        /// </summary>
        /// <returns>Una respuesta HTTP que contiene la lista de empleados en formato JSON.</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEmployees()
        {
            List<Employees> employees = _employeesLogic.GetAll();

            List<EmployeesView> employeesViews = employees.Select(s => new EmployeesView
            {
                EmployeeID = s.EmployeeID,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Title = s.Title,
            }).ToList();

            return Ok(employeesViews);
        }
        /// <summary>
        /// Obtiene un empleado por su ID.
        /// </summary>
        /// <param name="id">El ID del empleado.</param>
        /// <returns>Los datos del empleado o un error si no se encuentra.</returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetEmployee(int id)
        {
            try
            {
                Employees employee = _employeesLogic.GetEmployeeByID(id);

                if (employee == null)
                {
                    return NotFound();
                }

                EmployeesView employeesView = new EmployeesView
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                };

                return Ok(employeesView);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Crea un nuevo empleado.
        /// </summary>
        /// <param name="employeesView">Los datos del nuevo empleado.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateEmployee(EmployeesView employeesView)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(string.Join(", ", errors));
            }

            try
            {
                var employee = new Employees
                {
                    FirstName = employeesView.FirstName,
                    LastName = employeesView.LastName,
                    Title = employeesView.Title,
                };

                _employeesLogic.Add(employee);

                return Ok(new { success = true });
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Actualiza los datos de un empleado.
        /// </summary>
        /// <param name="id">El ID del empleado a actualizar.</param>
        /// <param name="employeesView">Los datos actualizados del empleado.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la operación.</returns>
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateEmployee(int id, EmployeesView employeesView)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(string.Join(", ", errors));
            }

            try
            {
                var employee = new Employees
                {
                    FirstName = employeesView.FirstName,
                    LastName = employeesView.LastName,
                    Title = employeesView.Title,
                };

                bool updated = _employeesLogic.Update(employee);

                if (!updated)
                {
                    return NotFound();
                }

                return Ok(new { success = true });
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        /// <summary>
        /// Elimina un empleado por su ID.
        /// </summary>
        /// <param name="id">El ID del empleado a eliminar.</param>
        /// <returns>Una acción de redirección a la página de inicio.</returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _employeesLogic.Delete(id);
                return Ok(new { success = true });
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}