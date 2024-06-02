namespace CineamService.Command.Movie.Delete
{
    public sealed class DeleteMovieCommand : ICommand
    {
        public DeleteMovieCommand(long id)
        {
            Id = id;
        }
        public long Id { get; }
    }
}
