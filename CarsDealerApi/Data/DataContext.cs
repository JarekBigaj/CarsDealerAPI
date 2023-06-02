using CarsDealerApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }


        public DbSet<Car> Cars => Set<Car>();
        public DbSet<User> Users => Set<User>();
        public DbSet<TestDrive> TestDrives => Set<TestDrive>();
        public DbSet<Offer> Offers => Set<Offer>();
        public DbSet<Purchase> Purchases => Set<Purchase>();

        
    }
}