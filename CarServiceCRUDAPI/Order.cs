using System.ComponentModel.DataAnnotations;

namespace CarServiceCRUDAPI
{
    public class Order
    {
        [Required]
        public Car car { get; set; }
        [Required]
        [RegularExpression("\"[0-9]{1,2}\\\\/[0-9]{1,2}\\\\/[0-9]{4}\"")]
        public string Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}