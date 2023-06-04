using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Model.API;

namespace ViewModel
{
    public partial class BookViewModel : ObservableObject
    {
        private IBookModel _addedBook;
        public BookViewModel()
        {
        }
        public BookViewModel(IBookModel addedBook)
        {
            _addedBook = addedBook;
        }

        public int BookId
        {
            get { return _addedBook.BookId; }
            set
            {
                _addedBook.BookId = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _addedBook.Title; }
            set
            {
                _addedBook.Title = value;
                OnPropertyChanged();
            }
        }
        public string Author
        {
            get { return _addedBook.Author; }
            set
            {
                _addedBook.Author = value;
                OnPropertyChanged();
            }
        }

        public string Publisher
        {
            get { return _addedBook.Publisher; }
            set
            {
                _addedBook.Publisher = value;
                OnPropertyChanged();
            }
        }

        public string Category
        {
            get { return _addedBook.Category; }
            set
            {
                _addedBook.Category = value;
                OnPropertyChanged();
            }
        }


        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
    }
}