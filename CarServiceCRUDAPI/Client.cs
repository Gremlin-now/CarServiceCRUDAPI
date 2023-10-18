namespace CarServiceCRUDAPI
{
    public class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone_number { get; set; }
        public string Address { get; set; }
        public List<Car> Cars = new List<Car>();
        public List<Order> Orders = new List<Order>();
    }
}
