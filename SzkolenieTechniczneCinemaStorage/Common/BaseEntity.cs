using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczneCinemaStorage.Common
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
