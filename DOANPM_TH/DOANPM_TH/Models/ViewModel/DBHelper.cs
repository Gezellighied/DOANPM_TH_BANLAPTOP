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
            List<Laptops> laptops = dbContext.Laptops.OrderByDescending(p => p.LaptopsID).ToList();
            return laptops;
        }
        public Laptops getLaptopsById(int id)
        {
            Laptops laptops = new Laptops();
            return laptops;
        }
        public Laptops GetLaptopsByName(string name)
        {
            Laptops laptops = new Laptops();
            return laptops;
        }
    }
}
