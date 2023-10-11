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
        public List<Laptops> getLaptops()
        {
            List<Laptops> laptops = dbContext.Laptops.OrderByDescending(p => p.LaptopID).ToList();
            return laptops;
        }
        public Laptops GetLaptopsById(int laptopID)
        {
            Laptops laptops = new Laptops();
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
        public Customer GetCustomerByEmail(string email)
        {
            return dbContext.Customers.Where(item => item.Email == email).FirstOrDefault();
        }

        // Tạo khách hàng
        public void CreateCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }
    }
}
