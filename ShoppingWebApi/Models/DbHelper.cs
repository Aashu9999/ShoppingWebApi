using ShoppingWebApi.EfCore;

namespace ShoppingWebApi.Models
{
    public class DbHelper
    {
        private EF_Data_Context _context;
        public DbHelper(EF_Data_Context context) 
        {
            
            _context = context; 

        }

        //GET

        public List<ProductModel> GetProducts() { 

            List<ProductModel> response = new List<ProductModel>();
            var datalist  = _context.Products.ToList();
            datalist.ForEach(row => response.Add(new ProductModel() { 
            
                brand=row.brand,
                id=row.id,
                name=row.name,
                price=row.price,
                Size=row.Size,
            }));

            return response; 
            
        
        }

       /* public List<ProductModel> GetProductsById(int id)
        {

            ProductModel response = new ProductModel();
            var row = _context.Products.Where(d => d.id.Equals(id)).FirstOrDefault();

            return new ProductModel()
            {

                brand = row.brand,
                id = row.id,
                name = row.name,
                price = row.price,
                Size = row.Size
            };

        }*/
        /// <summary>
        /// it serves the POST/PUT/PATCH
        /// </summary>
        public void SaveOrder(OrderModel orderModel)
        {
            Order dbTable = new Order();
            if (orderModel.id > 0) 
            { 
                //Put
                dbTable = _context.Orders.Where(d=>d.id.Equals(orderModel.id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.phone = orderModel.phone;
                    dbTable.address = orderModel.address;
                }

                else
                {
                    //post

                    dbTable.phone= orderModel.phone;
                    dbTable.name = orderModel.name;
                    dbTable.address = orderModel.address;
                    dbTable.Product = _context.Products.Where(f => f.id.Equals(orderModel.product_id)).FirstOrDefault();
                    _context.Orders.Add(dbTable);
                }
                
            }
        }

        ///delete

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

    }
}
