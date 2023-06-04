using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace ViewModel
{
    public partial class AddSupplierViewModel : ObservableObject
    {
        private IAddSupplierModel _addedSupplier;
        public AddSupplierViewModel()
        {
        }
        public AddSupplierViewModel(IAddSupplierModel addedSupplier)
        {
            _addedSupplier = addedSupplier;
        }

        public string Name
        {
            get { return _addedSupplier.Name; }
            set
            {
                _addedSupplier.Name = value;
                OnPropertyChanged();
            }
        }

        public string SupplierId
        {
            get { return _addedSupplier.SupplierId; }
            set
            {
                _addedSupplier.SupplierId = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get { return _addedSupplier.PhoneNumber; }
            set
            {
                _addedSupplier.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _addedSupplier.Address; }
            set
            {
                _addedSupplier.Address = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _addedSupplier.Email; }
            set
            {
                _addedSupplier.Email = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
    }