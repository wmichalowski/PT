using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model.API;
using Model.Implementation;

namespace ViewModel
{
    public partial class ReturnViewModel : ObservableObject
    {
        private IReturnModel _returnModel;
        private ObservableCollection<IReturnModel> _returns;
        private IReturnModel _selectedReturn;
        private bool _isDetailViewVisible;

        public ReturnViewModel()
        {
            _returnModel = new ReturnModel();
            LoadReturns();
            GoBackCommand = new RelayCommand(ExecuteGoBackCommand);
        }

        public ObservableCollection<IReturnModel> Returns
        {
            get { return _returns; }
            set
            {
                _returns = value;
                OnPropertyChanged(nameof(Returns));
            }
        }

        public IReturnModel SelectedReturn
        {
            get { return _selectedReturn; }
            set
            {
                _selectedReturn = value;
                OnPropertyChanged(nameof(SelectedReturn));
                IsDetailViewVisible = _selectedReturn != null;
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

        private void LoadReturns()
        {
            Returns = new ObservableCollection<IReturnModel>(_returnModel.GetAllReturns());
        }

        public int ReturnId
        {
            get { return _returnModel?.ReturnId ?? 0; }
            set
            {
                if (_returnModel != null)
                {
                    _returnModel.ReturnId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int BookId
        {
            get { return _returnModel?.BookId ?? 0; }
            set
            {
                if (_returnModel != null)
                {
                    _returnModel.BookId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int EmployeeId
        {
            get { return _returnModel?.EmployeeId ?? 0; }
            set
            {
                if (_returnModel != null)
                {
                    _returnModel.EmployeeId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ReaderId
        {
            get { return _returnModel?.ReaderId ?? 0; }
            set
            {
                if (_returnModel != null)
                {
                    _returnModel.ReaderId = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand GoBackCommand { get; }

        private void ExecuteGoBackCommand()
        {
            // Clear the selected return and hide the detail view
            SelectedReturn = null;
        }
    }
}
