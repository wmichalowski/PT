using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class Book : IBook
    {
        public Book(int id, string title) {
            Id = id; 
            Title = title;
        }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}