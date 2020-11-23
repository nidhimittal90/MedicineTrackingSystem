using MedicinesUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicinesUI.Services.Interface
{
    public interface IMedicineRepository
    {
        public Medicine AddMedicine(Medicine medicine);
        public List<Medicine> GetMedicineList();
        Medicine UpdateMedicine(int id, string notes);
    }
}
