/*using System.Collections.ObjectModel;
using System.ComponentModel;
using Model.API;
using System.Windows.Input;


namespace ViewModel
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private readonly IBookModel bookModel;
        public event PropertyChangedEventHandler PropertyChanged;

        public BookViewModel(IBookModel bookModel)
        {
            this.bookModel = bookModel;
            LoadBooks();
        }

        private ObservableCollection<IBookModel> books;
        public ObservableCollection<IBookModel> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        private void LoadBooks()
        {
            // Retrieve the list of books from the model
            var bookList = bookModel.GetAllBooks();

            // Create an observable collection from the book list
            Books = new ObservableCollection<BookModel>(bookList);
        }

        // Implement INotifyPropertyChanged interface
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

    }
}
*/