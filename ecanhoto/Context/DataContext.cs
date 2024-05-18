using Microsoft.EntityFrameworkCore;

namespace ecanhoto.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EcanhotoDB;ConnectRetryCount=0");





        }

    }
}
