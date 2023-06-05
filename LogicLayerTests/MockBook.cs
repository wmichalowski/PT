using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    internal class MockBook : IBook
    {
        public MockBook(int id, string title, string author, string category, string publisher)
        {
            Id = id;
            Title = title;
            Author = author;
            Category = category;
            Publisher = publisher;

        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
    }
}
