using LogicLayer.API;
using Model.API;

namespace Model.Implementation
{
    public class SupplierModel : ISupplierModel
    {
        private readonly IBusinessLogic _businessLogic;

        public SupplierModel()
        {
            _businessLogic = IBusinessLogic.BusinessLogicFactory();
        }

        public SupplierModel(IBusinessLogic bl)
        {
            _businessLogic = bl;
        }

        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public void AddSupplier(int supplierId, string name, string phoneNumber, string address, string email)
        {
            SupplierId = supplierId;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;

            _businessLogic.AddSupplier(supplierId, name, phoneNumber, address, email);
        }

        public void RemoveSupplier(int supplierId)
        {
            _businessLogic.RemoveSupplier(supplierId);
        }

        public IEnumerable<ISupplierModel> GetAllSuppliers()
        {
            var suppliers = _businessLogic.GetAllSuppliers();

            var supplierModels = suppliers.Select(supplier => new SupplierModel()
            {
                SupplierId = supplier.Id,
                Name = supplier.Name,
                PhoneNumber = supplier.PhoneNumber,
                Address = supplier.Address,
                Email = supplier.Email
            });

            return supplierModels;
        }
    }
}
