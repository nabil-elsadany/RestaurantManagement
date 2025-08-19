namespace RestaurantManagement.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public int GuestsCount { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
