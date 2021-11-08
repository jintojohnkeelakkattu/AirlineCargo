using AirlineCargo.Models;
using AirlineCargo.Utility;
using System.Text;

namespace AirlineCargo.OrderHandler
{
    public class OrderHandler : IOrderHandler
    {

        public void SetOrderForFlight(List<FlightDetails> flights)
        {
            try
            {
                var order = new List<CargoOrder>();
                CargoOrder cargo = null;
                var list = CommonUtility.GetJsonData();
                var exceptlist = list;
                foreach (var item in flights.Where(s => s.Day == 1))
                {
                    var info = list.Where(s => s.destination == item.Arrival).ToList();

                    if (info != null)
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            cargo = new CargoOrder();
                            var res = FetchFilghtdata(info, i, 20);
                            var tempOrder = res.Select(s => new CargoOrder
                            {
                                day = i,
                                Order = s.OrderKey,
                                arrival = s.destination,
                                Departure = item.Departure,
                                FlightNumber = flights.Where(s => s.Day == i &&
                                s.Arrival == item.Arrival).Select(s => s.Flight).FirstOrDefault()
                            }).ToList();
                            order.Concat(tempOrder);
                            PrintFlightData(tempOrder);
                        }
                    }
                    exceptlist.RemoveAll(s => s.destination == item.Arrival);

                }
                PrintUnscheduledFlightData(exceptlist);

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected List<Order> FetchFilghtdata(List<Order> oderList, int pageNumber, int pageSize)
        {
            var slice = oderList.Skip((pageNumber - 1) * pageSize)
                  .Take(pageSize);
            return slice.ToList();
        }
        protected void PrintFlightData(List<CargoOrder> tempOrder)
        {
            foreach (var flight in tempOrder)
            {
                var sb = new StringBuilder();
                var data = ($" {"Order"} :{flight.Order}{','}{" "}" +
                    $"{"flightNumber"} :{flight.FlightNumber}{','}{" "}" +
                    $"{"departure"} :{flight.Departure}{','}{" "}" +
                    $"{"arrival"} :{flight.arrival}{','}{" "}" +
                    $"{"day"} :{flight.day}"
                    );
                sb.Append(data);
                Console.WriteLine(sb.ToString());
                Console.Write("\r\n");
            }
        }
        protected void PrintUnscheduledFlightData(List<Order> order)
        {
            foreach (var flight in order)
            {
                var sb = new StringBuilder();
                var data = ($" {"Order"} :{flight.OrderKey}{','}{" "}" +
                    $"{"flightNumber"} :{" not scheduled"}");
                sb.Append(data);
                Console.WriteLine(sb.ToString());
                Console.Write("\r\n");
            }
        }
    }
}
