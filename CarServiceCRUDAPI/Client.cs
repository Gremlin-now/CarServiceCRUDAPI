using System.ComponentModel.DataAnnotations;

namespace CarServiceCRUDAPI
{
    public class Client
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [RegularExpression("+7 [0-9]{3} [0-9]{3}-[0-9]{2}-[0-9]{2}")]
        public string Phone_number { get; set; }
        public string Address { get; set; }
        public List<Car> Cars = new List<Car>();
        public List<Order> Orders = new List<Order>();
    }
}
