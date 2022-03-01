using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Entities;
using DataAccess;

namespace Business
{
    public class B_Category 
    {
        public static List<CategoryEntity> ItemList()
        {
           using (var db = new InventaryContext())
            {
                return db.Categories.ToList();
            }
        }


        public static void CreateItem(CategoryEntity item)
        {
            using(var db = new InventaryContext())
            {
                db.Categories.Add(item);
                db.SaveChanges();
            }
        }

        public static void DeleteItem(CategoryEntity item)
        {
            using (var db=new InventaryContext())
            {
                db.Remove(item);
                db.SaveChanges();
            }
        }

      

        public static void UpdateItem(CategoryEntity item)
        {
            using (var db= new InventaryContext())
            {
                db.Update(item);
                db.SaveChanges();
            }
        }
    }
}
