using MedicinesTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicinesTracking.Services.Interface
{
    public interface IRepository
    {
        public Medicine AddMedicine(Medicine medicine);
        public MedicineList GetMedicineList();
        Medicine UpdateMedicine(int id, Medicine request);
    }
}
