using Practica6.MVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica6.MVC.Logic
{
    public class EmployeesLogic : BaseLogic, IABMLogic<Employees>
    {
        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Add(Employees newEmployee)
        {
            if (string.IsNullOrEmpty(newEmployee.FirstName) || string.IsNullOrEmpty(newEmployee.LastName) || string.IsNullOrEmpty(newEmployee.Title))
            {
                throw new ArgumentException("El nombre, apellido y puesto laboral del empleado son obligatorios.");
            }

            context.Employees.Add(newEmployee);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employeeToDelete = context.Employees.Find(id);
            if (employeeToDelete != null)
            {
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El empleado no existe.");
            }
        }

        public void Update(Employees employee)
        {
            var employeeUpdate = context.Employees.Find(employee.EmployeeID);
            if (employeeUpdate != null)
            {
                employeeUpdate.FirstName = employee.FirstName;
                employeeUpdate.LastName = employee.LastName;
                employeeUpdate.Title = employee.Title;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El empleado no existe.");
            }
        }

        public Employees GetEmployeeByID(int id)
        {
            return context.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }
    }

}
