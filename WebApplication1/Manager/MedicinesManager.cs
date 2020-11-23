using DotNetty.Common.Utilities;
using MedicinesTracking.Manager.Interfaces;
using MedicinesTracking.Models;
using MedicinesTracking.Services;
using MedicinesTracking.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicinesTracking.Manager
{
    public class MedicinesManager : IMedicinesManager
    {
        private readonly IRepository _repository;
        public MedicinesManager(IRepository repository)
        {
            _repository = repository;
        }
        public MedicineList GetMedicines()
        {
            return _repository.GetMedicineList();
        }

        public Medicine SaveNewMedicine(Medicine request)
        {
            return _repository.AddMedicine(request);
        }


        public Medicine UpdateMedicine(int id, Medicine request)
        {
            return _repository.UpdateMedicine(id, request);
        }
    }
}