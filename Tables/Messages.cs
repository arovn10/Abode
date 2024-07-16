

namespace Abode.Tables
{
    public class Messages
    {
        public int MessageID { get; set; } // Primary Key
        public int? propertyID { get; set; }
        public string? messages { get; set; }
        public DateTime? dateTime { get; set; }
        public string? senderUsername { get; set; }
        public string? sendeeUsername { get; set; }



    }
}
