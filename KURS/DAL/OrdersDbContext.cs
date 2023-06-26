using KURS.Models.DBentities;
using Microsoft.EntityFrameworkCore;

namespace KURS.DAL
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Orders> Orders { get; set; }
    }
}
