using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class Book : IBook
    {
        public Book(int id, string title, string author, string category, string publisher) {
            Id = id; 
            Title = title;
            Author = author;
            Category = category;
            Publisher = publisher;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
    }
}