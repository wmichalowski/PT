using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.API;
using System.Collections.ObjectModel;
using Model.Implementation;

namespace ViewModel
{
    public partial class ReaderViewModel : ObservableObject
    {
        private IReaderModel _readerModel;
        private ObservableCollection<IReaderModel> _readers;
        private IReaderModel _selectedReader;
        private bool _isDetailViewVisible;

        public ReaderViewModel()
        {
            _readerModel = new ReaderModel();
            LoadReaders();
            ShowMoreCommand = new RelayCommand<object>(ExecuteShowMoreCommand);
            GoBackCommand = new RelayCommand(ExecuteGoBackCommand);
        }

        public ObservableCollection<IReaderModel> Readers
        {
            get { return _readers; }
            set
            {
                _readers = value;
                OnPropertyChanged(nameof(Readers));
            }
        }

        public IReaderModel SelectedReader
        {
            get { return _selectedReader; }
            set
            {
                _selectedReader = value;
                OnPropertyChanged(nameof(SelectedReader));
                IsDetailViewVisible = _selectedReader != null;
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

        private void LoadReaders()
        {
            Readers = new ObservableCollection<IReaderModel>(_readerModel.GetAllReaders());
        }

        public string Name
        {
            get { return _readerModel?.Name ?? "DefaultName"; }
            set
            {
                if (_readerModel != null)
                {
                    _readerModel.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Surname
        {
            get { return _readerModel?.Surname ?? "DefaultSurname"; }
            set
            {
                if (_readerModel != null)
                {
                    _readerModel.Surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ReaderId
        {
            get { return _readerModel?.ReaderId ?? 0; }
            set
            {
                if (_readerModel != null)
                {
                    _readerModel.ReaderId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get { return _readerModel?.PhoneNumber ?? "DefaultPhoneNumber"; }
            set
            {
                if (_readerModel != null)
                {
                    _readerModel.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get { return _readerModel?.Address ?? "DefaultAddress"; }
            set
            {
                if (_readerModel != null)
                {
                    _readerModel.Address = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get { return _readerModel?.Email ?? "DefaultEmail"; }
            set
            {
                if (_readerModel != null)
                {
                    _readerModel.Email = value;
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
            // Get the selected Reader from the command parameter
            IReaderModel selectedReader = parameter as IReaderModel;

            // Set the selected book as the currently displayed Reader
            SelectedReader = selectedReader;
        }

        private void ExecuteGoBackCommand()
        {
            // Clear the selected Reader and hide the detail view
            SelectedReader = null;
        }
    }
}