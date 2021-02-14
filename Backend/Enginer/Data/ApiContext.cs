using Business;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApiContext : DbContext
    {
      
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        // Injeção do Business no ApiContext
        public DbSet<Client> Client { get; set; }
        public DbSet<Gender> Gender { get; set; }

    }
}
