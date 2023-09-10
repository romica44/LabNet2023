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
        public void Update(Customers employee)
        {
            throw new NotImplementedException();
        }
        public void Add(Customers element)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
