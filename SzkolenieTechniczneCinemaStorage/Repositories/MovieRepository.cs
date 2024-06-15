

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SzkolenieTechniczneCinemaStorage.Entities;

namespace SzkolenieTechniczneCinemaStorage.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaTicketDbContext _context;
        public MovieRepository(CinemaTicketDbContext context)
        {

        }
        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void AddSeance(Seance seance)
        {
            _context.Seances.Add(seance);
            _context.SaveChanges();
        }

        public void BuyTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            _context.Movies.Update(movie);
        }

        public Movie GetMovieById(long id)
        {
            return _context.Movies.Include(c => c.Seances).ThenInclude(c => c.Tickets).SingleOrDefault(x => x.Id == id);
            //var movie = _context.Movies.Find(id);
            //return movie;
        }

        public List<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetSeanceDetails(long movieId)
        {
            return _context.Movies.Where(x => x.Id == movieId).Include(t => t.Seances).SingleOrDefault();
        }

        public List<Seance> GetSeancesByMovieId(long movieId)
        {
            return _context.Seances.Where(x => x.MovieId == movieId).ToList();
        }

        public bool IsMovieExist(long movieId)
        {
            return _context.Movies.Any(x => x.Id == movieId);
        }

        public bool IsMovieExist(string name, int year)
        {
            return _context.Movies.Any(x => x.Name == name && x.Year == year);
        }

        public bool IsSeanceExist(DateTime date)
        {
            return _context.Seances.Any(x => x.Date == date);
        }

        public void RemoveMovie(long id)
        {
            var movie = _context.Movies.Find(id);
            if (movie is null)
                return;
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
