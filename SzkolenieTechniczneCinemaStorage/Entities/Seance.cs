using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczneCinemaStorage.Common;

namespace SzkolenieTechniczneCinemaStorage.Entities
{
    [Table("Seances", Schema = "Cinema")]
    public class Seance : BaseEntity
    {
        protected Seance() { }
        public Seance(DateTime date, long movieId, int numberoOfTickets) 
        { 
            Date= date;
            MovieId = movieId;
            NumberOfTickets = numberoOfTickets;
        }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int NumberOfTickets { get; set; }

        [Required]
        public long MovieId { get; set; }

        [Required]
        public Movie? Movie { get; set; }

        public ICollection<Seance> Seances { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
