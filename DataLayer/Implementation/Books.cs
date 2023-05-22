using DataLayer.API;
using System.Data.Linq.Mapping;

namespace DataLayer.Implementation
{
    [Table(Name = "Books")]
    public class Book: IBook
    {
        [Column(Name = "Title")]
        public string Title { get; set; }

        [Column(Name = "Author")]
        public string Author { get; set; }

        [Column(Name = "BookId", IsPrimaryKey = true)]
        public string BookId { get; set; }

        [Column(Name = "Publisher")]
        public string Publisher { get; set; }

        [Column(Name = "Category")]
        public string Category { get; set; }

        [Column(Name = "Available")]
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