using Microsoft.EntityFrameworkCore;
using Minda_Iulia_Proiect.Models;

namespace Minda_Iulia_Proiect.Data
{
    public class RentalDbContext: DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options): base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
