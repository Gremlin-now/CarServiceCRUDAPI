using System.ComponentModel.DataAnnotations;

namespace CarServiceCRUDAPI
{
    public class Car
    {
        [Required]
        public string Mark { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }
        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string VINCode { get; set; }
    }
}
