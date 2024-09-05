namespace Abode.Tables
{
    public class RentalListings
    {
        public int ListingID { get; set; }
        public string? PropertyName { get; set; }
        public string? Address { get; set; }
        public decimal? MonthlyRent { get; set; }
        public DateOnly? AvailableDate { get; set; }
    }
}
