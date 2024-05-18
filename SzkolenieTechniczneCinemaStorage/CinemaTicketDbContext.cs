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
            options.UseSqlServer(@"Server = 10.200.2.28; Database = cinema-dev-w67739; User Id = stud; Password =wsiz;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Cinema"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}