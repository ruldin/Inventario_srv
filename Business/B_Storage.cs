
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class B_Storage 
    {
        public static StorageEntity CreateItem(StorageEntity item)
        {
            using (var db = new InventaryContext())
            {
                db.Storages.Add(item);
                db.SaveChanges();

                return GetStorageById(item.StorageId);
            }
        }

        public static bool IsProductInWarehouse(string idStorage)
        {
            //con esto validamos si ya hay un producto en la bodega
            using (var db = new InventaryContext())
            {
                var product = db.Storages.ToList()
                    .Where(x => x.StorageId == idStorage);


                return product.Any(); //retorna si se cumple la condicion
            }
        }

        public static List<StorageEntity> ItemList()
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                   
                    .ToList();
            }
        }


        public static List<StorageEntity> StorageProductByWarehouse(string idWarehouse)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                     .Where(s => s.WarehouseId == idWarehouse)
                    .ToList();
            }
        }




        public static void UpdateItem(StorageEntity item)
        {
            item.dateTime = DateTime.Now;

            using (var db = new InventaryContext())
            {
                db.Storages.Update(item);
                db.SaveChanges();
            }
        }


        /* NUEVO MÉTODO */
        public static StorageEntity GetStorageById(string id)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                    .ToList()
                    .LastOrDefault(s => s.StorageId == id);
            }
        }

      

        /* NUEVO MÉTODO */
        public static List<StorageEntity> StorageListByWarehouse(string idWarehouse)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                    .Where(s => s.WarehouseId == idWarehouse)
                    .ToList();
            }
        }


    }//end class
}
