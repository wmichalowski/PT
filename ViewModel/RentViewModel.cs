using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model.API;
using Model.Implementation;

namespace ViewModel
{
    public partial class RentViewModel : ObservableObject
    {
        private IRentModel _rentModel;
        private ObservableCollection<IRentModel> _rents;
        private IRentModel _selectedRent;
        private bool _isDetailViewVisible;

        public RentViewModel()
        {
            _rentModel = new RentModel();
            LoadRents();
            ShowMoreCommand = new RelayCommand<object>(ExecuteShowMoreCommand);
            GoBackCommand = new RelayCommand(ExecuteGoBackCommand);
        }

        public ObservableCollection<IRentModel> Rents
        {
            get { return _rents; }
            set
            {
                _rents = value;
                OnPropertyChanged(nameof(Rents));
            }
        }

        public IRentModel SelectedRent
        {
            get { return _selectedRent; }
            set
            {
                _selectedRent = value;
                OnPropertyChanged(nameof(SelectedRent));
                IsDetailViewVisible = _selectedRent != null;
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

        private void LoadRents()
        {
            Rents = new ObservableCollection<IRentModel>(_rentModel.GetAllRents());
        }

        public int RentId
        {
            get { return _rentModel?.RentId ?? 0; }
            set
            {
                if (_rentModel != null)
                {
                    _rentModel.RentId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ReaderId
        {
            get { return _rentModel?.ReaderId ?? 0; }
            set
            {
                if (_rentModel != null)
                {
                    _rentModel.ReaderId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int EmployeeId
        {
            get { return _rentModel?.EmployeeId ?? 0; }
            set
            {
                if (_rentModel != null)
                {
                    _rentModel.EmployeeId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int BookId
        {
            get { return _rentModel?.BookId ?? 0; }
            set
            {
                if (_rentModel != null)
                {
                    _rentModel.BookId = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowMoreCommand { get; }
        public ICommand GoBackCommand { get; }

        private void ExecuteShowMoreCommand(object parameter)
        {
            // Get the selected rent from the command parameter
            IRentModel selectedRent = parameter as IRentModel;

            // Set the selected rent as the currently displayed rent
            SelectedRent = selectedRent;
        }

        private void ExecuteGoBackCommand()
        {
            // Clear the selected rent and hide the detail view
            SelectedRent = null;
        }
    }
}
