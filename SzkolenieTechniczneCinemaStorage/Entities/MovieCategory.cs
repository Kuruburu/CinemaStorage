using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczneCinemaStorage.Common;

namespace SzkolenieTechniczneCinemaStorage.Entities
{
    [Table("MovieCategories", Schema = "Cinema")]
    public class MovieCategory : BaseEntity
    {
        protected MovieCategory() { }
        public MovieCategory(string category, string description) 
        {
            Category = category;
            Description = description;
        }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string? Category { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string? Description { get; set; }
    }  
}
