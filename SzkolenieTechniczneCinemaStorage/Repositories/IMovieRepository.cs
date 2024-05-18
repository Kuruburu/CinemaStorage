using SzkolenieTechniczneCinemaStorage.Entities;

namespace SzkolenieTechniczneCinemaStorage.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
        Movie GetMovieById(long id);

        void AddMovie(Movie movie);

        void EditMovie(Movie movie);
        void RemoveMovie(long id);
        bool IsMovieExist(long movieId);
        bool IsMovieExist(string name, int year);
        bool IsSeanceExist(DateTime date);

        void AddSeance(Seance seance);
        void BuyTicket(Ticket ticket);
        List<Seance> GetSeancesByMovieId();
        Movie GetSeanceDetails(long movieId);
    }
}
