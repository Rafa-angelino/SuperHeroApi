global using Microsoft.EntityFrameworkCore;

namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;DataBase=superHeroDb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
