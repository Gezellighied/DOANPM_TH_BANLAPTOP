using System.Collections.Generic;
using DOANPM_TH.Models.ClassModel;
using Microsoft.EntityFrameworkCore;
namespace DOANPM_TH.Models.ViewModel
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Laptops> Laptops { get; set; }
    }
}
