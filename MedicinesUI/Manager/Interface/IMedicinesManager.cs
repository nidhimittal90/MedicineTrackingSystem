using MedicinesUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicinesUI.Manager.Interface
{
    public interface IMedicinesManager
    {
        List<Medicine> GetMedicines();
        Medicine SaveNewMedicine(Medicine request);
        Medicine UpdateMedicine(int id, string notes);
    }
}
