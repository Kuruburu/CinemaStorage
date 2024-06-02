

using System.Diagnostics.CodeAnalysis;
using CineamService.Command.Add;
using SzkolenieTechniczneCinemaStorage.Entities;
using SzkolenieTechniczneCinemaStorage.Repositories;

namespace CineamService.Command.Movie.Add
{
    public sealed class AddMovieCommandHandler : ICommandHandler<AddMovieCommand>
    {
        private readonly IMovieRepository _repository;

        public AddMovieCommandHandler(IMovieRepository repostory)
        {
            _repository = repostory;
        }

        public Result Handle(AddMovieCommand command)
        {
            var validatoinResult = new AddMovieCommandValidator().Validate(command);
            if (validatoinResult.IsValid == false)
            {
                return Result.Fail(validatoinResult);
            }

            var isExist = _repository.IsMovieExist(command.Name, command.Year);

            if (isExist)
            {
                return Result.Fail("This Movie already exists");
            }

            var movie = new Movie(command.Name, command.Year, command.SeanceTime, command.Description, command.CategoryId);
            _repository.AddMovie(movie);

            return Result.OK();
        }
    }
}
