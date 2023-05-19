using Service.API;

namespace Service.Model
{
	internal class BooksModel : IBook
	{
		public internal class BooksModel : IBooks(string title, string author, string bookId, string publisher, string category, bool availablee, IService servicee)
		{
			Title = title;
            Author = author;
            BookId = bookId;
            Publisher = publisher;
            Category = category;
            Available = available;
			Servicee = servicee;
		}

		public string Title { get; set; }
		public string Author { get; set; }
		public string BookId { get; set; }
		public string Publisher { get; set; }
		public string Category { get; set; }
		public bool Available { get; set; }

		public IService Servicee { get; }

		public async Task AddAsync()
		{
			await Servicee.AddBook(Title, Author, BookId, Publisher, Category, Available);
		}

		public async Task DeleteAsync()
		{
			await Servicee.DeleteCatalog(Id);
		}

	}


}