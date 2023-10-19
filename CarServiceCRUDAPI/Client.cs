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
        [RegularExpression("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$")]
        public string Phone_number { get; set; }
        public string Address { get; set; }
    }
}
