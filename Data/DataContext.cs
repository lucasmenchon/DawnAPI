using DawnAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DawnAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ContactModel> ContactsTable { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
