
namespace CineamService.Command.Delete
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
