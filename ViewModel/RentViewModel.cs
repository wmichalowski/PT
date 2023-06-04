using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input; 

namespace ViewModel
{
	public partial class RentViewModel : ObservableObject
	{
		private IRentModel _rent;
		public RentViewModel()
		{
		}
		public RentViewModel(IRentModel rent)
		{
			_rent = rent;
		}

		public string BookId
		{
			get { return _rent.BookId; }
			set
			{
				_rent.BookId = value;
				OnPropertyChanged();
			}
		}

		public string ReaderId
		{
			get { return _rent.ReaderId; }
			set
			{
				_rent.ReaderId = value;
				OnPropertyChanged();
			}
		}
		public string EmployeeId
		{
			get { return _rent.EmployeeId; }
			set
			{
				_rent.EmployeeId = value;
				OnPropertyChanged();
			}
		}

		public string RentId
		{
			get { return _rent.RentId; }
			set
			{
				_rent.RentId = value;
				OnPropertyChanged();
			}
		}

		public ICommand AddCommand { get; }
	}
}