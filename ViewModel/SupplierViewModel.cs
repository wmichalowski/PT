using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;
using Model.API;
using System.Collections.ObjectModel;
using Model.Implementation;

namespace ViewModel
{
    public partial class SupplierViewModel : ObservableObject
    {
        private ISupplierModel _supplierModel;
        private ObservableCollection<ISupplierModel> _suppliers;
        private ISupplierModel _selectedSupplier;
        private bool _isDetailViewVisible;

        public SupplierViewModel()
        {
            _supplierModel = new SupplierModel();
            LoadSuppliers();
            ShowMoreCommand = new RelayCommand<object>(ExecuteShowMoreCommand);
            GoBackCommand = new RelayCommand(ExecuteGoBackCommand);
        }

        public ObservableCollection<ISupplierModel> Suppliers
        {
            get { return _suppliers; }
            set
            {
                _suppliers = value;
                OnPropertyChanged(nameof(Suppliers));
            }
        }

        public ISupplierModel SelectedSupplier
        {
            get { return _selectedSupplier; }
            set
            {
                _selectedSupplier = value;
                OnPropertyChanged(nameof(SelectedSupplier));
                IsDetailViewVisible = _selectedSupplier != null;
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

        private void LoadSuppliers()
        {
            Suppliers = new ObservableCollection<ISupplierModel>(_supplierModel.GetAllSuppliers());
        }

        public string Name
        {
            get { return _supplierModel?.Name ?? "DefaultName"; }
            set
            {
                if (_supplierModel != null)
                {
                    _supplierModel.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SupplierId
        {
            get { return _supplierModel?.SupplierId ?? 0; }
            set
            {
                if (_supplierModel != null)
                {
                    _supplierModel.SupplierId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get { return _supplierModel?.PhoneNumber ?? "DefaultPhoneNumber"; }
            set
            {
                if (_supplierModel != null)
                {
                    _supplierModel.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get { return _supplierModel?.Address ?? "DefaultAddress"; }
            set
            {
                if (_supplierModel != null)
                {
                    _supplierModel.Address = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get { return _supplierModel?.Email ?? "DefaultEmail"; }
            set
            {
                if (_supplierModel != null)
                {
                    _supplierModel.Email = value;
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
            // Get the selected Supplier from the command parameter
            ISupplierModel selectedSupplier = parameter as ISupplierModel;

            // Set the selected Supplier as the currently displayed Supplier
            SelectedSupplier = selectedSupplier;
        }

        private void ExecuteGoBackCommand()
        {
            // Clear the selected Supplier and hide the detail view
            SelectedSupplier = null;
        }
    }
}
