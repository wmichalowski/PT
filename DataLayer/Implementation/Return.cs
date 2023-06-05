using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class Return : IReturn
    {
        public Return(int returnId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp)
        {
            ReturnId = returnId;
            ReaderId = readerId;
            BookId = bookId;
            EmployeeId = employeeId;
            Intent = intent;
            Timestamp = timestamp;
        }

        public int ReturnId { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public int EmployeeId { get; set; }
        public string Intent { get; set; }
        public DateTime Timestamp
        {
            get; set;
        }
    }
}
