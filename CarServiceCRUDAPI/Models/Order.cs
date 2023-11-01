using System.ComponentModel.DataAnnotations;

namespace CarServiceCRUDAPI.Models
{
    public class Order : IModel
    {
        [Required]
        public int CarID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        [RegularExpression("\"[0-9]{1,2}\\\\/[0-9]{1,2}\\\\/[0-9]{4}\"")]
        public string Date { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }
}