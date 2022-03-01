using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface I_Crud<T>
    {
        List<T> ItemList();
        void CreateItem(T item);
        void DeleteItem(T item);
        void UpdateItem(T item);

        
    }
}
