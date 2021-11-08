namespace AirlineCargo.Models
{
    public class FlightDetails
    {

        public int Flight { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Day { get; set; }
        public FlightDetails(int  day, int flightId, string departure, string arrival)
        {

            this.Flight = flightId;
            this.Departure = departure;
            this.Arrival = arrival;
            this.Day = day;
        }
    }
}
