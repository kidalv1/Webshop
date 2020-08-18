using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BL
{
    interface IManager<T>
    {
        void Add(T t);
        T FindById(int? id);
        void Modify();
        List<T> GetAll();
        void Remove(T t);
    }
}
