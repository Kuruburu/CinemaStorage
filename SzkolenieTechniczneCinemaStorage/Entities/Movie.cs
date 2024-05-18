using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczneCinemaStorage.Common;

namespace SzkolenieTechniczneCinemaStorage.Entities
{
    [Table("Movies", Schema ="Cinema")]
    public class Movie : BaseEntity
    {
        protected Movie() { }
        public Movie(string name, int year, int seanceTime, string description, long categoryId) 
        {
            Name = name;
            Year = year;
            TimeMinutes = seanceTime;
            Description = description;

            IsActive = true;
        }

        [Required]
        [MinLength(3)]
        [MaxLength(128)]
        public string? Name{ get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public int TimeMinutes { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }
        public ICollection<Seance> Seances { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
