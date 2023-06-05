using LogicLayer.API;
using Model.API;
using System.Collections.ObjectModel;

namespace Model.Implementation
{
    public class BookModel : IBookModel
    {
        private readonly IBusinessLogic _businessLogic;

        public BookModel()
        {
            _businessLogic = IBusinessLogic.BusinessLogicFactory();
        }

        public BookModel(IBusinessLogic bl)
        {
            _businessLogic = bl;
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }

        public void AddBook(int bookId, string title, string author, string category, string publisher)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Category = category;
            Publisher = publisher;

            _businessLogic.AddBook(bookId, title, author, category, publisher);
        }

        public void RemoveBook(int bookId)
        {
            _businessLogic.RemoveBook(bookId);
        }

        public IEnumerable<IBookModel> GetAllBooks()
        {
            try
            {
                var books = _businessLogic.GetAllBooks();

                var bookModels = books.Select(book => new BookModel()
                {
                    BookId = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category,
                    Publisher = book.Publisher
                });
                return bookModels;
            }
            catch (Exception) { 
                return GetExampleBooks();
                
            }
            
        }

        private IEnumerable<IBookModel> GetExampleBooks()
        {
            // Create example book data
            var exampleBooks = new ObservableCollection<IBookModel>
        {
            new BookModel { Title = "Example Book 1", Author = "John Doe", Category = "Fiction", Publisher = "Example Publisher 1" },
            new BookModel { Title = "Example Book 2", Author = "Jane Smith", Category = "Non-fiction", Publisher = "Example Publisher 2" },

        };

            return exampleBooks;
        }
    }
}
