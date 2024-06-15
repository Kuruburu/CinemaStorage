using CineamService.Command.Movie.Add;
using CineamService.Query.Dtos;
using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczneCinemaStorage.Repositories;

namespace SzkolenieTechniczne.Cinema.Controllers
{
    public class MovieController : Controller
    {
        private static List<MovieDto> _movies = new List<MovieDto>()
        {
            new MovieDto("Terminator", 2),
            new MovieDto("Rambo", 2)
        };

        public MovieController() { }
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            //var handler = new GetAllMoviesQueryHandler(_movieRepository);
            //var query = new GetAll
            return View(_movies);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddMovieCommand command)
        {
            _movies.Add(new MovieDto(command.Name, 1));
            return RedirectToAction("Index");
        }

        //public IActionResult Edit(long id) { }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            return RedirectToAction("Index");
        }
    }
}
