﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface IRentModel
    {
        int BookId { get; set; }
        int ReaderId { get; set; }
        int EmployeeId { get; set; }
        int RentId { get; set; }

        void AddRent(int bookId, int readerId, int employeeId, int rentId);
        void RemoveRent(int rentId);
        IEnumerable<IRentModel> GetAllRents();
    }
}
