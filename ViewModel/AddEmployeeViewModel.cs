using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace ViewModel
{
    public partial class AddEmployeeViewModel : ObservableObject
    {
        private IAddEmployeeModel _addedEmployee;
        public AddEmployeeViewModel()
        {
        }
        public AddEmployeeViewModel(IAddEmployeeModel addedEmployee)
        {
            _addedEmployee = addedEmployee;
        }

        public string Name
        {
            get { return _addedEmployee.Name; }
            set
            {
                _addedEmployee.Name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _addedEmployee.Surname; }
            set
            {
                _addedEmployee.Surname = value;
                OnPropertyChanged();
            }
        }
        public string EmployeeId
        {
            get { return _addedEmployee.EmployeeId; }
            set
            {
                _addedEmployee.EmployeeId = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get { return _addedEmployee.PhoneNumber; }
            set
            {
                _addedEmployee.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _addedEmployee.Address; }
            set
            {
                _addedEmployee.Address = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _addedEmployee.Email; }
            set
            {
                _addedEmployee.Email = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
}