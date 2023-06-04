using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Implementation
{
    public class SupplierModel : ISupplierModel
    {
        public string Name { get; set; }
        public string SupplierId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        private List<ISupplierModel> supplierList;

        public SupplierModel()
        {
            supplierList = new List<ISupplierModel>();
        }

        public void AddSupplier(string name,  string supplierId, string phoneNumber, string address, string email)
        {
            supplierList.Add(new SupplierModel
            {
                Name = name,
                SupplierId = supplierId,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email
            });
        }

        public void RemoveSupplier(string supplierId)
        {
            var supplierToRemove = supplierList.Find(supplier => supplier.SupplierId == supplierId);
            if (supplierToRemove != null)
                supplierList.Remove(supplierToRemove);
        }

        public IEnumerable<ISupplierModel> GetAllSuppliers()
        {
            return supplierList;
        }
    }
}
