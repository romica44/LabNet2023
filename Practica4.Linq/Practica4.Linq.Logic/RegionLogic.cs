using Practica4.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.Linq.Logic
{
    public class RegionLogic: BaseLogic
    {
        public List<Region> GetAll()
        {
            return context.Region.ToList();
        }
    }
}
