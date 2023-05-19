using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class Book: IBook
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

        public override bool Equals(object? obj)
        {

            Book? book = obj as Book;

            if (book == null) return false;

            return this.Available == book.Available &&
                this.Title == book.Title &&
                this.Author == book.Author &&
                this.BookId == book.BookId &&
                this.Publisher == book.Publisher &&
                this.Category == book.Category;
        }

        public override int GetHashCode()
        {
            return BookId.GetHashCode();
        }
    }

}