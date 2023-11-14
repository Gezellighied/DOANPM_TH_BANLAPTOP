using DOANPM_TH.Models.ClassModel;
using Microsoft.EntityFrameworkCore;

namespace DOANPM_TH.Models.ViewModel
{
    public class DBHelper
    {
        DatabaseContext dbContext;
        public DBHelper(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //-------------------------------------------------------------------------Laptop--------------------------------------------------
        public List<Laptops> getLaptops()
        {
            List<Laptops> laptops = dbContext.Laptops.OrderByDescending(p => p.LaptopID).ToList();
            return laptops;
        }
        public Laptops GetLaptopsById(int laptopID)
        {
            Laptops laptops = dbContext.Laptops.FirstOrDefault(p => p.LaptopID == laptopID); ;
            return laptops;
        }
        public Laptops GetLaptopDetails(int? laptopId)
        {
            return dbContext.Laptops.FirstOrDefault(p => p.LaptopID == laptopId);
        }
        public Laptops GetLaptopsByName(string name)
        {
            Laptops laptops = new Laptops();
            return laptops;
        }
        //public Customer GetCustomerByEmail(string email)
        //{
        //	return dbContext.Customers.Where(item => item.Email == email).FirstOrDefault();
        //}

        // Tạo khách hàng
        //public void CreateCustomer(Customer customer)
        //{
        //	dbContext.Customers.Add(customer);
        //	dbContext.SaveChanges();
        //}
        public List<Laptops> SearchLaptop(String searchSLaptop)
        {
            return dbContext.Laptops.Where(p => p.LaptopName.Contains(searchSLaptop)).OrderByDescending(p => p.LaptopID).ToList();
        }
        public void InsertLaptop(Laptops newLaptops)
        {
            dbContext.Laptops.Add(newLaptops);
            dbContext.SaveChanges();
        }
        public Laptops GetNewLaptop()
        {
            return dbContext.Laptops.OrderByDescending(p => p.LaptopID).FirstOrDefault();
        }
        public void DeleteLaptop(int laptopId)
        {
            dbContext.Laptops.Remove(GetLaptopsById(laptopId));
            dbContext.SaveChanges();
        }
        public void UpdateLaptop(Laptops newLatop)
        {
            dbContext.Laptops.Update(newLatop);
            dbContext.SaveChanges();
        }
        //--------------------------------------------------------------------Khách Hàng----------------------------------------------
        // Tìm khách hàng theo Email
        public Customer GetCustomerByEmail(string email)
        {
            return dbContext.Customer.Where(item => item.Email == email).FirstOrDefault();
        }

        // Tạo khách hàng
        public void CreateCustomer(Customer customer)
        {
            dbContext.Customer.Add(customer);
            dbContext.SaveChanges();
        }
        //---------------------------------------------------------------------Giỏ Hàng----------------------------------------------
        public List<Cart> GetMyCartByCustomerId(int? customerId)
        {
            List<Cart> carts = dbContext.Carts.Include(c => c.Laptop).Include(c => c.Customer).Where(c => c.CustomerID == customerId).ToList();
            return carts;
        }

        // tính số lưởng sản phẩm trong giỏ hàng
        public int GetCountMyCart(int? customerId)
        {
            int countCart = dbContext.Carts.Include(c => c.Laptop).Include(c => c.Customer).Where(c => c.CustomerID == customerId).ToList().Count;
            return countCart;
        }

        public Cart GetCartById(int cartId)
        {
            return dbContext.Carts.Include(c => c.Laptop).Include(c => c.Customer).FirstOrDefault(c => c.CartID == cartId);
        }

        // xóa sản phẩm trong giỏ hàng
        public void DeleteProductInCart(int cardId)
        {
            dbContext.Carts.Remove(GetCartById(cardId));
            dbContext.SaveChanges();

        }

        //chỉnh sửa số lượng sản phẩm trong giỏ hàng
        public void EditQuantityPro(int cartId, int quanti, out int total)
        {
            total = 0;

            var cart = dbContext.Carts.Include(p => p.Laptop).FirstOrDefault(c => c.CartID == cartId);
            if (cart != null)
            {
                cart.Quantity = quanti;
                total = cart.Laptop.Price * quanti;
                dbContext.SaveChanges();
            }
        }

        // lấy danh sách order
        public List<Order> GetOrderByCustomerId(int customerId)
        {
            return dbContext.Orders.Include(item => item.Customer).Where(item => item.CustomerID == customerId).OrderByDescending(item => item.OrderID).ToList();
        }

        // lấy danh sách chi tiết đơn hàng theo orderid
        public List<OrderDetails> GetListOrderDetailsByOrderId(int orderId)
        {
            return dbContext.OrderDetails.Include(item => item.Laptops).Include(item => item.Order).Where(item => item.OrderID == orderId).ToList();
        }

        // đặt hàng
        public void CreateOrder(Order order, List<Cart> listCart)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            foreach (var item in listCart)
            {
                OrderDetails orderDetails = new OrderDetails()
                {
                    OrderID = order.OrderID,
                    LaptopID = item.LaptopID,
                    Price = item.Laptop.Price,
                    Quantity = item.Quantity,
                    Total = item.Laptop.Price * item.Quantity
                };

                CreateOrderDetails(orderDetails);
            }

            DeleteAllCart(listCart);
        }

        // tạo chi tiết đơn hàng
        public void CreateOrderDetails(OrderDetails orderDetails)
        {
            dbContext.OrderDetails.Add(orderDetails);
            dbContext.SaveChanges();
        }

        // xóa sản phẩm trong giỏ hàng
        public void DeleteAllCart(List<Cart> carts)
        {
            dbContext.Carts.RemoveRange(carts);
            dbContext.SaveChanges();
        }
        public void AddItemToCart(Cart cart)
        {
            dbContext.Carts.Add(cart);
            dbContext.SaveChanges();
        }

    }
}