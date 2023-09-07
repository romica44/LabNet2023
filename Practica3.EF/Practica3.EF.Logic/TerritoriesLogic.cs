using Practica6.MVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Practica6.MVC.Logic
{
    public class TerritoriesLogic : BaseLogic, IABMLogic<Territories>
    {
        public void Add(Territories element)
        {
            if (string.IsNullOrEmpty(element.TerritoryDescription))
            {
                throw new ArgumentException("La descripción del territorio es obligatoria.");
            }

            context.Territories.Add(element);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var territorioAEliminar = context.Territories.Find(id);
            if (territorioAEliminar != null)
            {
                context.Territories.Remove(territorioAEliminar);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El territorio no existe.");
            }
        }

        public List<Territories> GetAll()
        {
            return context.Territories.ToList();
        }

        public void Update(Territories territorio)
        {
            var territorioUpdate = context.Territories.Find(territorio.TerritoryID);
            if (territorioUpdate != null)
            {
                territorioUpdate.TerritoryDescription = territorio.TerritoryDescription;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El territorio no existe.");
            }
        }
    }
}
