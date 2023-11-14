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
	}
}
