using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczneCinemaStorage.Common;

namespace SzkolenieTechniczneCinemaStorage.Entities
{
    [Table("Tickets", Schema = "Cinema")]
    public class Ticket : BaseEntity
    {
        protected Ticket() { }
        public Ticket(string email, int numberOfTickets) 
        {
            Email= email;
            NumberOfTickets = numberOfTickets;
        }

        [Required]
        [MinLength(5)]
        [MaxLength(128)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(9)]
        [MaxLength(28)]
        [Phone]
        public string? Phone { get; set; }

        [Range(1, 10)]
        public int NumberOfTickets { get; set; }

        [Required]
        public long SeanceId { get; set; }
        public Seance? Seance { get; set; }

    }
}
