using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SzkolenieTechniczneCinemaStorage.Entities;

namespace SzkolenieTechniczneCinemaStorage
{
    public class CinemaTicketDbContext : DbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<MovieCategory> MoviesCategories { get; set; }
        public CinemaTicketDbContext(IConfiguration configuration) : base ()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=WellBeingDiary;Trusted_Connection=true;TrustServerCertificate=true;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Cinema"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
