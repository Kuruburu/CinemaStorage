namespace CineamService.Command.Seance.RegisterSeance
{
    public class RegisterSeanceCommand : ICommand
    {
        public long MovieId { get; set; }
        public DateTime SeanceDate { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
