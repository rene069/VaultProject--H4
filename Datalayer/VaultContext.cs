using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Datalayer
{
    public class VaultContext : DbContext
    {

        public DbSet<User> users { get; set; }


        public VaultContext(DbContextOptions<VaultContext>? options) : base(options)
        {

        }
        

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Kode 123456
            modelBuilder.Entity<User>().HasData(new User {UserId = 1, UserName = "Rene", PassSalt = "ixn9BGA9T/wITRafF9GvDg==", PassHash = "+tHY5nbYkgMSuKXF2fVJGt+vjf33W6tF+2vR4worGUk=" });
        }
    }
}