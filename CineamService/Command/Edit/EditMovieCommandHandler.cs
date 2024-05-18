using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczneCinemaStorage.Repositories;

namespace CineamService.Command.Edit
{
    public sealed class EditMovieCommandHandler
    {
        private readonly IMovieRepository _repository;
        public EditMovieCommandHandler(IMovieRepository repository)
        {
            _repository = repository;
        }
        public Result Hande(EditMovieCommand command)
        {
            var validationResult = new EditMovieCommandValidator().Validate(command);
            if(validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var movie = _repository.GetMovieById(command.Id);
            if (movie == null)
            {
                return Result.Fail("Movie does not exist.");
            }

            movie.Name = command.Name;
            movie.Year = command.Year;
            movie.TimeMinutes = command.SeanceTime;

            _repository.EditMovie(movie);

            return Result.OK();
        }
    }
}
