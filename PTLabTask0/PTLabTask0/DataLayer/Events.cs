using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class BookCheckout
    {
        public Users User { get; set; }
        public Books Book { get; set; }

        public DateTime Timestamp { get; set; }

    }

    internal class BookReturn
    {
        public Users User { get; set; }
        public Books Book { get; set; }
        public Books BookId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    internal class BookAcquisition
    {
        public Users User { get; set; }
        public Books Book { get; set; }
        public DateTime Timestamp { get; set; }
    }

    internal class BookDeletion
    {

    }
}
