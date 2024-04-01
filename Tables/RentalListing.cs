namespace Abode.Tables
{
    public class RentalListing
    {
        public int ListingID { get; set; }
        public string? PropertyName { get; set; }
        public string? Address { get; set; }
        public int? MonthlyRent { get; set; }
        public DateOnly? AvailableDate { get; set; }
    }
}
