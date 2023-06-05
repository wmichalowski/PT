using DataLayer.API;
using LogicLayer.API;
using Model.API;
using System.Collections.Generic;
using System.Linq;

public class TestBusinessLogic : IBusinessLogic
{
    private List<IBook> _books;

    public TestBusinessLogic()
    {
        _books = new List<IBook>();
    }

    public void AddBook(int Id, string Title, string Author, string Category, string Publisher)
    {
        var book = new IBook(Id, Title, Author, Category, Publisher)
        _books.Add(book);
    }

    public void RemoveBook(int Id)
    {
        var book = _books.FirstOrDefault(b => b.Id == Id);
        if (book != null)
            _books.Remove(book);
    }

    public IEnumerable<IBook> GetAllBooks()
    {
        return _books;
    }

    public void updateBook(int Id, string Title, string Author, string Category, string Publisher)
    {
        throw new NotImplementedException();
    }

    IEnumerable<IBook> IBusinessLogic.GetAllBooks()
    {
        throw new NotImplementedException();
    }
}
}