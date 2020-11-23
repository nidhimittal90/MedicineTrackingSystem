using MedicinesTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicinesTracking.Manager.Interfaces
{
    public interface IMedicinesManager
    {
        MedicineList GetMedicines();
        Medicine SaveNewMedicine(Medicine request);
        Medicine UpdateMedicine(int id, Medicine request);
    }
}
