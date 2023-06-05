using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IReturn
    {
        public int ReturnId { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public int EmployeeId { get; set; }
        public string Intent { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
