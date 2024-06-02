using CineamService.Command.Movie.Add;
using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczneCinemaStorage.Repositories;

namespace SzkolenieTechniczne.Cinema.Controllers
{
    public class MovieConroller : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieConroller(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            //var handler = new GetAllMoviesQueryHandler(_movieRepository);
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddMovieCommand command)
        {
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
