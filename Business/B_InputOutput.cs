using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using DataAccess;
using Entities;

namespace Business
{
    public class B_InputOutput 
    {
        public static void CreateItem(InputOutputEntity item)
        {
            using (var db = new InventaryContext())
            {
                db.InOuts.Add(item);
                db.SaveChanges();
            }
        }

       

        public static List<InputOutputEntity> ItemList()
        {
            using (var db = new InventaryContext())
            {
                return db.InOuts.ToList();
            }
        }

        public static void UpdateItem(InputOutputEntity item)
        {
            using (var db = new InventaryContext())
            {
                db.InOuts.Update(item);
                db.SaveChanges();
            }
        }
    }
}
