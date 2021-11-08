using AirlineCargo.Models;

namespace AirlineCargo.OrderHandler
{
    public class OrderConcreate
    {
        public IOrderHandler _orderHandler;
        public OrderConcreate(IOrderHandler orderHandler)
        {
            this._orderHandler = orderHandler;
        }
        public void InvokeMethod(List<FlightDetails> flights)
        {
            this._orderHandler.SetOrderForFlight(flights);
        }
    }
}
