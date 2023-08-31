using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public class EmployeesLogic : BaseLogic, IABMLogic<Employees>
    {
        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Add(Employees newEmployee)
        {
            if (string.IsNullOrEmpty(newEmployee.FirstName) || string.IsNullOrEmpty(newEmployee.LastName))
            {
                throw new ArgumentException("El nombre y apellido del empleado son obligatorios.");
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
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El empleado no existe.");
            }
        }
    }

}
