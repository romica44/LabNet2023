using Practica7.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica7.WebApi.Logic
{
    public class RegionLogic : BaseLogic, IABMLogic<Region>
    {
        public List<Region> GetAll()
        {
            return context.Region.ToList();
        }

        public void Add(Region newRegion)
        {
            if (string.IsNullOrEmpty(newRegion.RegionDescription))
            {
                throw new ArgumentException("La descripción de la región es obligatoria.");
            }

            context.Region.Add(newRegion);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var regionAEliminar = context.Region.Find(id);
            if (regionAEliminar != null)
            {
                context.Region.Remove(regionAEliminar);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("La región no existe.");
            }
        }

        public void Update(Region region)
        {
            var regionUpdate = context.Region.Find(region.RegionID);
            if (regionUpdate != null)
            {
                regionUpdate.RegionDescription = region.RegionDescription;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("La región no existe.");
            }
        }
    }
}
