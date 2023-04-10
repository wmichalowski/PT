using DataLayer.API;

namespace DataLayer.Implementation
{
    public class Book: IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookId { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public bool Available { get; set; }

        public Book(string title, string author, string bookId, string publisher, string category, bool available)
        {
            Title = title;
            Author = author;
            BookId = bookId;
            Publisher = publisher;
            Category = category;
            Available = available;
        }
    }

}