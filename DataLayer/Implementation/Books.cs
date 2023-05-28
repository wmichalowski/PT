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

        public Book() { }

    public Book(string title, string author, string bookId, string publisher, string category, bool available)
        {
            Title = title;
            Author = author;
            BookId = bookId;
            Publisher = publisher;
            Category = category;
            Available = available;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Book book)
                return false;

            if (Title != book.Title)
            {
                Console.WriteLine($"Title mismatch: Expected '{Title}', Actual '{book.Title}'");
                return false;
            }

            if (Author != book.Author)
            {
                Console.WriteLine($"Author mismatch: Expected '{Author}', Actual '{book.Author}'");
                return false;
            }

            if (BookId != book.BookId)
            {
                Console.WriteLine($"BookId mismatch: Expected '{BookId}', Actual '{book.BookId}'");
                return false;
            }

            if (Publisher != book.Publisher)
            {
                Console.WriteLine($"Publisher mismatch: Expected '{Publisher}', Actual '{book.Publisher}'");
                return false;
            }

            if (Category != book.Category)
            {
                Console.WriteLine($"Category mismatch: Expected '{Category}', Actual '{book.Category}'");
                return false;
            }

            if (Available != book.Available)
            {
                Console.WriteLine($"Available mismatch: Expected '{Available}', Actual '{book.Available}'");
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, BookId, Publisher, Category, Available);
        }
    }

}