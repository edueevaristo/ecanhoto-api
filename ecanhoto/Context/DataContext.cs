using ecanhoto.Model;
using Microsoft.EntityFrameworkCore;

namespace ecanhoto.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EcanhotoDB;ConnectRetryCount=0");
        }

        public DbSet<Canhoto> Canhoto { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Status> Status { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
                    Username = "System",
                    Password = "System",
                }
            );
        }

    }
}
