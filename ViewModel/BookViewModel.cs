using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Model.API;
using System.Collections.ObjectModel;
using Model.Implementation;

namespace ViewModel
{
    public partial class BookViewModel : ObservableObject
    {
        private IBookModel _bookModel;
        private ObservableCollection<IBookModel> _books;
        private IBookModel _selectedBook;
        private bool _isDetailViewVisible;

        public BookViewModel()
        {
            _bookModel = new BookModel();
            LoadBooks();
            ShowMoreCommand = new RelayCommand<object>(ExecuteShowMoreCommand);
            GoBackCommand = new RelayCommand(ExecuteGoBackCommand);
        }

        public ObservableCollection<IBookModel> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public IBookModel SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
                IsDetailViewVisible = _selectedBook != null;
            }
        }

        public bool IsDetailViewVisible
        {
            get { return _isDetailViewVisible; }
            set
            {
                _isDetailViewVisible = value;
                OnPropertyChanged(nameof(IsDetailViewVisible));
            }
        }

        private void LoadBooks()
        {
            Books = new ObservableCollection<IBookModel>(_bookModel.GetAllBooks());
        }

        public int BookId
        {
            get { return _bookModel?.BookId ?? 0; }
            set
            {
                if (_bookModel != null)
                {
                    _bookModel.BookId = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Title
        {
            get { return _bookModel?.Title ?? "DefaultTitle"; }
            set
            {
                if (_bookModel != null)
                {
                    _bookModel.Title = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Author
        {
            get { return _bookModel?.Author ?? "DefaultAuthor"; }
            set
            {
                if (_bookModel != null) { 
                    _bookModel.Author = value;
                    OnPropertyChanged();
                }
                
            }
        }

        public string Publisher
        {
            get { return _bookModel?.Publisher ?? "DefaultPublisher"; }
            set
            {
                if (_bookModel != null)
                {
                    _bookModel.Publisher = value;
                    OnPropertyChanged();
                }
                
            }
        }

        public string Category
        {
            get { return _bookModel?.Category ?? "DefaultCategory"; }
            set
            {
                if (_bookModel != null) { 
                    _bookModel.Category = value;
                    OnPropertyChanged();
                }
               
            }
        }


        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ICommand ShowMoreCommand { get; }
        public ICommand GoBackCommand { get; }

        private void ExecuteShowMoreCommand(object parameter)
        {
            // Get the selected book from the command parameter
            IBookModel selectedBook = parameter as IBookModel;

            // Set the selected book as the currently displayed book
            SelectedBook = selectedBook;
        }

        private void ExecuteGoBackCommand()
        {
            // Clear the selected book and hide the detail view
            SelectedBook = null;
        }

    }
}