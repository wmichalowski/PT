using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface ISupplierModel
    {
        int SupplierId { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Email { get; set; }

        void AddSupplier(int supplierId, string name, string phoneNumber, string address, string email);
        void RemoveSupplier(int supplierId);
        IEnumerable<ISupplierModel> GetAllSuppliers();
    }
}
