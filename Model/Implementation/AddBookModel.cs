using LogicLayer.API;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.API;
using LogicLayer.API;


namespace Model.Implementation
{
    public class AddBookModel : IAddBookModel
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }

        private readonly IBookModel bookModel;

        public AddBookModel(IBookModel bookModel)
        {
            this.bookModel = bookModel;
        }

        public async Task AddBookAsync()
        {
            // Perform the logic to add a new book using the bookModel
            int bookId = int.Parse(BookId);
            bookModel.AddBook(bookId, Title, Author, Category, Publisher);

            // Reset the properties to clear the input fields
            BookId = string.Empty;
            Title = string.Empty;
            Author = string.Empty;
            Category = string.Empty;
            Publisher = string.Empty;
        }
    }
}