using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CSharp_1280706
{
    public interface IMedicine<T> where T : class
    {
        void MADD(T obj);
        void MRemove(T item);
        List<T> GetAll();
    }
}
