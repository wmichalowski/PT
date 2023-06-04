using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace ViewModel
{
    public partial class RetrunViewModel : ObservableObject
    {
        private IRetrunModel _return;

        public RetrunViewModel()
        {
        }

        public RetrunViewModel(IReturnModel return)
        {
            _return = retrun;
        }

        public string BookId
        {
            get { return _return.BookId; }
            set
            {
                _return.BookId = value;
                OnPropertyChanged();
            }
        }

        public string ReaderId
        {
            get { return _return.ReaderId; }
            set
            {
                _return.ReaderId = value;
                OnPropertyChanged();
            }
        }
        public string EmployeeId
        {
            get { return _return.EmployeeId; }
            set
            {
                _return.EmployeeId = value;
                OnPropertyChanged();
            }
        }

        public string ReturnId
        {
            get { return _return.ReturnId; }
            set
            {
                _return.ReturnId = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
    }
}