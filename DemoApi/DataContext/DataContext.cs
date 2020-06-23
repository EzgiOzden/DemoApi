using DemoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //Modeller buraya
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
