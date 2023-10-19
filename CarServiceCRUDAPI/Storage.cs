
namespace CarServiceCRUDAPI
{
    public static class Storage
    {
        public static int LastClientsKey = 0;
        public static Dictionary<int, Client> Clients = new Dictionary<int, Client>();
        public static int LastOrdersKey = 0;
        public static Dictionary<int, Order> Orders = new Dictionary<int, Order>();
        public static int LastCarsKey = 0;
        public static Dictionary<int, Car> Cars = new Dictionary<int, Car>();

        public static List<Car> FindAllCarsForClient(int clientID)
        {
            List<Car> cars = new List<Car>();
            foreach (var item in FindAllOrdersForClient(clientID))
            {
                cars.Add(Cars[item.CarID]);
            }
            return cars;
        }
        public static List<Order> FindAllOrdersForClient(int clientID)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in Orders)
            {
                if(item.Value.ClientID == clientID)
                {
                    orders.Add(item.Value);
                }
            }
            return orders;
        }
    }
}
