using AirlineCargo.Models;

namespace AirlineCargo.OrderHandler
{
    public interface IOrderHandler
    {
        public void SetOrderForFlight(List<FlightDetails> flights);
    }
}
