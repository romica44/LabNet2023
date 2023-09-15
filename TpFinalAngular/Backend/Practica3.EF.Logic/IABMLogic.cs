using System.Collections.Generic;

namespace Practica7.WebApi.Logic
{
    interface IABMLogic<T>
    {
        List<T> GetAll();
        void Add(T element);
        void Delete(int id);
        void Update(T element);
    }
}
