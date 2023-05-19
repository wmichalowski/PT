using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{

	internal class BookRent : IRent_Return
	{
		public string ReaderId { get; set; }
		public string BookId { get; set; }
		public string EmployeeId { get; set; }
		public DateTime Timestamp { get; set; }

		public BookRent(string readerId, string bookId, string employeeId, DateTime timestamp)
		{
			ReaderId = readerId;
			BookId = bookId;
			EmployeeId = employeeId;
			Timestamp = timestamp;
		}
	}

	internal class BookReturn : IRent_Return
	{
		public string ReaderId { get; set; }
		public string BookId { get; set; }
		public string EmployeeId { get; set; }
		public DateTime Timestamp { get; set; }

		public BookReturn(string readerId, string bookId, string employeeId, DateTime timestamp)
		{
			ReaderId = readerId;
			BookId = bookId;
			EmployeeId = employeeId;
			Timestamp = timestamp;
		}
	}

	internal class BookAcquisition : IBookAcquisition
	{
		public string SupplierId { get; set; }
		public string BookId { get; set; }
		public IBook Book { get; set; }
		public string EmployeeId { get; set; }
		public DateTime Timestamp { get; set; }

		public BookAcquisition(string supplierId, string bookId, IBook book, string employeeId, DateTime timestamp)
		{
			SupplierId = supplierId;
			BookId = bookId;
			Book = book;
			EmployeeId = employeeId;
			Timestamp = timestamp;

		}
	}

	internal class BookDeletion : IBookDeletion
	{
		public string BookId { get; set; }
		public string EmployeeId { get; set; }
		public DateTime Timestamp { get; set; }

		public BookDeletion(string bookId, string employeeId, DateTime timestamp)
		{
			BookId = bookId;
			EmployeeId = employeeId;
			Timestamp = timestamp;
		}
	}

	public async Task AddAsync()
	{
		public void BookAcquisition(IBook book, string supplierId, string employeeId)
		{
			if (_dataRepository.GetBookById(book.BookId) == null)
			{
				_dataRepository.AddBook(book);
				_events.RecordBookAcquisition(book, supplierId, employeeId, DateTime.Now);
			}
			else
			{
				throw new ArgumentException("Book already exists");
			}
		}

		public void UpdateBook(IBook book)
		{
			if (_dataRepository.GetBookById(book.BookId) != null)
			{
				_dataRepository.UpdateBook(book);
			}
		}

		public void BookDeletion(string bookId, string employeeId)
		{
			if (_dataRepository.GetBookById(bookId) != null)
			{
				_dataRepository.DeleteBook(bookId);
				_events.RecordBookDeletion(bookId, employeeId, DateTime.Now);
			}
		}

		public void BookRent(string bookId, string readerId, string employeeId)
		{
			IBook bookToRent = _dataRepository.GetBookById(bookId);
			if (_dataRepository.GetBookById(bookId) != null && bookToRent.Available == true)
			{
				bookToRent.Available = false;
				_events.RecordBookCheckout(bookId, readerId, employeeId, DateTime.Now);
			}
		}

		public void BookReturn(string bookId, string readerId, string employeeId)
		{
			IBook bookToRent = _dataRepository.GetBookById(bookId);

			if (_dataRepository.GetBookById(bookId) != null && bookToRent.Available == false)
			{

				bookToRent.Available = true;
				_events.RecordBookCheckout(bookId, readerId, employeeId, DateTime.Now);
			}
		}

	}
}
