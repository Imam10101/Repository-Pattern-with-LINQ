using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_CSharp_1280706
{
    public class IMedicineBase<T> : IMedicine<T> where T : class
    {
        List<T> data = new List<T>();
        public List<T> GetAll()
        {
            return data;
        }

        public void MADD(T obj) 
        {
            data.Add(obj);
        }

        public void MRemove(T item)
        {
            data.Remove(item);
        }
    }                                            
}
