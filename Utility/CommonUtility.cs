using AirlineCargo.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace AirlineCargo.Utility
{
    public static class CommonUtility
    {
        public static List<FlightDetails> CreateFilghtInfo()
        {
            var charterInfo = new List<FlightDetails>();
            charterInfo.Add(new FlightDetails(1, 1, "YUL", "YYZ"));
            charterInfo.Add(new FlightDetails(2, 4, "YUL", "YYZ"));
            charterInfo.Add(new FlightDetails(1, 2, "YUL", "YYC"));
            charterInfo.Add(new FlightDetails(2, 5, "YUL", "YYC"));
            charterInfo.Add(new FlightDetails(1, 3, "YUL", "YVR"));
            charterInfo.Add(new FlightDetails(2, 6, "YUL", "YVR"));
            return charterInfo;
        }
        public static void GetCharterInfo(List<FlightDetails> flights)
        {
            StringBuilder info = null;
            foreach (var flight in flights)
            {
                info = new StringBuilder();
                foreach (PropertyInfo prop in flight.GetType().GetProperties())
                {
                    var item = ($" {prop.Name} :{prop.GetValue(flight, null).ToString()}{','}");
                    info.Append(item);
                }
                Console.Write(info.Remove(info.Length - 1, 1));
                Console.WriteLine();
            }
        }

        public static List<Order> GetJsonData()
        {
            List<Order> ordrList = new List<Order>();
            var url = System.AppContext.BaseDirectory;
            var mainpath = url.Replace("\\bin\\Debug\\net6.0", "");
            string absolutePath = Path.GetFullPath(mainpath + "orders.json");
            using (StreamReader r = new StreamReader(absolutePath))
            {
                string json = r.ReadToEnd();
                dynamic input = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);

                foreach (var item in input)
                {
                    Order ob = new Order();
                    ob.OrderKey = item.Key;
                    ob.destination = item.Value.destination;
                    ordrList.Add(ob);
                    ob = null;
                }
            }
            return ordrList;
        }
    }
}
