using LogicLayer.API;
using Model.API;

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
            var books = _businessLogic.GetAllBooks();

            var bookModels = books.Select(book => new BookModel()
            {
                BookId = book.Id,
                Title = book.Title,
                Author = book.Author,
                Category = book.Category,
                Publisher = book.Publisher
            }) ;

            return bookModels;
        }
    }
}
