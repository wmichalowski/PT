using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Model.API;
using System.Collections.ObjectModel;
using Model.Implementation;

namespace ViewModel
{
    public partial class EmployeeViewModel : ObservableObject
    {
        private IEmployeeModel _employeeModel;
        private ObservableCollection<IEmployeeModel> _employees;
        private IEmployeeModel _selectedEmployee;
        private bool _isDetailViewVisible;

        public EmployeeViewModel()
        {
            _employeeModel = new EmployeeModel();
            LoadEmployees();
            ShowMoreCommand = new RelayCommand<object>(ExecuteShowMoreCommand);
            GoBackCommand = new RelayCommand(ExecuteGoBackCommand);
        }

        public ObservableCollection<IEmployeeModel> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public IEmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
                IsDetailViewVisible = _selectedEmployee != null;
            }
        }

        public bool IsDetailViewVisible
        {
            get { return _isDetailViewVisible; }
            set
            {
                _isDetailViewVisible = value;
            }
        }

        private void LoadEmployees()
        {
            Employees = new ObservableCollection<IEmployeeModel>(_employeeModel.GetAllEmployees());
        }

        public string Name
        {
            get { return _employeeModel?.Name ?? "DefaultName"; }
            set
            {
                if (_employeeModel != null)
                {
                    _employeeModel.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Surname
        {
            get { return _employeeModel?.Surname ?? "DefaultSurname"; }
            set
            {
                if (_employeeModel != null)
                {
                    _employeeModel.Surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EmployeeId
        {
            get { return _employeeModel?.EmployeeId ?? "DefaultEmployeeId"; }
            set
            {
                if (_employeeModel != null)
                {
                    _employeeModel.EmployeeId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get { return _employeeModel?.PhoneNumber ?? "DefaultPhoneNumber"; }
            set
            {
                if (_employeeModel != null)
                {
                    _employeeModel.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get { return _employeeModel?.Address ?? "DefaultAddress"; }
            set
            {
                if (_employeeModel != null)
                {
                    _employeeModel.Address = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get { return _employeeModel?.Email ?? "DefaulEmail"; }
            set
            {
                if (_employeeModel != null)
                {
                    _employeeModel.Email = value;
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
            // Get the selected Employee from the command parameter
            IEmployeeModel selectedEmployee = parameter as IEmployeeModel;

            // Set the selected Employee as the currently displayed Employee
            SelectedEmployee = selectedEmployee;
        }

        private void ExecuteGoBackCommand()
        {
            // Clear the selected Employee and hide the detail view
            SelectedEmployee = null;
        }
    }
}