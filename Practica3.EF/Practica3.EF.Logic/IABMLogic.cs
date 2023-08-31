using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    interface IABMLogic<T>
    {
        List<T> GetAll();
        void Add(T element);
        void Delete(int id);
        void Update(T element);
    }
}
