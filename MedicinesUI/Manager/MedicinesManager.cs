using MedicinesUI.Manager.Interface;
using MedicinesUI.Model;
using MedicinesUI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicinesUI.Manager
{
    public class MedicinesManager:IMedicinesManager
    {
        private readonly IMedicineRepository _repository;
        public MedicinesManager(IMedicineRepository repository)
        {
            _repository = repository;
        }
        public List<Medicine> GetMedicines()
        {
            return _repository.GetMedicineList();
        }

        public Medicine SaveNewMedicine(Medicine request)
        {
            return _repository.AddMedicine(request);
        }


        public Medicine UpdateMedicine(int id, string notes)
        {
            return _repository.UpdateMedicine(id, notes);
        }
    }
}
