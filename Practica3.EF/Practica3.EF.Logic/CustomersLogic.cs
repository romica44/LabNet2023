using Practica6.MVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica6.MVC.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }
        public void Update(Customers customers)
        {
            var customerUpdate = context.Customers.Find(customers.CustomerID);
            if (customerUpdate != null)
            {
                customerUpdate.CompanyName = customers.CompanyName;
                customerUpdate.ContactName = customers.ContactName;
                customerUpdate.Phone = customers.Phone;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El Cliente no existe.");
            }
        }
        public void Add(Customers customers)
        {
            if (string.IsNullOrEmpty(customers.CompanyName) || string.IsNullOrEmpty(customers.ContactName) || string.IsNullOrEmpty(customers.Phone))
            {
                throw new ArgumentException("Company Name, Contact Name y Phone son obligatorios.");
            }

            context.Customers.Add(customers);
            context.SaveChanges();
        }
        public Customers GetCustomerByID(string id)
        {
            return context.Customers.FirstOrDefault(e => e.CustomerID == id);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
