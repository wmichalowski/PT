using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace ViewModel
{
    public partial class AddReaderViewModel : ObservableObject
    {
        private IAddReaderModel _addedReader;
        public AddReaderViewModel()
        {
        }
        public AddReaderViewModel(IAddReaderModel addedReader)
        {
            _addedReader = addedReader;
        }

        public string Name
        {
            get { return _addedReader.Name; }
            set
            {
                _addedReader.Name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _addedReader.Surname; }
            set
            {
                _addedReader.Surname = value;
                OnPropertyChanged();
            }
        }
        public string ReaderId
        {
            get { return _addedReader.EmployeeId; }
            set
            {
                _addedReader.ReaderId = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get { return _addedReader.PhoneNumber; }
            set
            {
                _addedReader.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _addedReader.Address; }
            set
            {
                _addedReader.Address = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _addedReader.Email; }
            set
            {
                _addedReader.Email = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
    }