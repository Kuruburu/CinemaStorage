using SzkolenieTechniczneCinemaStorage.Repositories;

namespace CineamService.Command.Seance.RegisterSeance
{
    public class RegisterSeanceCommandHandler
    {

        private readonly IMovieRepository _repository;

        public RegisterSeanceCommandHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(RegisterSeanceCommand command)
        {
            var validationResult = new RegisterSeanceCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var isSeanceExist = _repository.IsSeanceExist(command.SeanceDate);
            if (isSeanceExist)
            {
                return Result.Fail("This seance already exist");
            }

            var movie = _repository.GetMovieById(command.MovieId);
            if (movie == null)
            {
                return Result.Fail("This movie does not exist");
            }

            var seance = new SzkolenieTechniczneCinemaStorage.Entities.Seance(command.SeanceDate, command.MovieId, command.NumberOfTickets);

            movie.Seances.Add(seance);

            return Result.OK();
        }
    }
}
