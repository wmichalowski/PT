using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class Rent: IRent
    {
        public Rent(int rentId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp)
        {
            RentId = rentId;
            ReaderId = readerId;
            BookId = bookId;
            EmployeeId = employeeId;
            Intent = intent;
            Timestamp = timestamp;
        }

        public int RentId { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public int EmployeeId { get; set; }
        public string Intent { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
