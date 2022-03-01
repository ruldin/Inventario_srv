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
    public class B_Warehouse : I_Crud<WarehouseEntity>
    {
        public void CreateItem(WarehouseEntity item)
        {
            using (var db = new InventaryContext())
            {
                db.Warehouses.Add(item);
                db.SaveChanges();
            }
        }

        public void DeleteItem(WarehouseEntity item)
        {
            throw new NotImplementedException();
        }

        public List<WarehouseEntity> ItemList()
        {
            using (var db = new InventaryContext())
            {
                return db.Warehouses.ToList();
            }
        }

        public void UpdateItem(WarehouseEntity item)
        {
            using (var db = new InventaryContext())
            {
                db.Warehouses.Update(item);
                db.SaveChanges();
            }
        }
    }
}
