using SzkolenieTechniczneCinemaStorage;
using SzkolenieTechniczneCinemaStorage.Repositories;

namespace SzkolenieTechniczne.Cinema.Extensions
{
    public static class CinemaExtensions
    {
        public static IServiceCollection AddCinemaServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMovieRepository, MovieRepository>();
            serviceCollection.AddDbContext<CinemaTicketDbContext>();
            return serviceCollection;
        }
    }
}
