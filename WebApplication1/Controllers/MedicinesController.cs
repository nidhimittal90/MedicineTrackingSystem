using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicinesTracking.Manager.Interfaces;
using MedicinesTracking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicinesTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicinesManager _medicinesManager;
        public MedicinesController(IMedicinesManager medicinesManager)
        {
            _medicinesManager = medicinesManager;
        }

        // GET: api/Medicines

        [HttpGet]
        public ActionResult GetMedicinesList()
        {
            var result =_medicinesManager.GetMedicines();
            return new OkObjectResult(result);
        }
        
        // POST: api/Medicines
        [HttpPost]
        public ActionResult AddMedicine([FromBody] Medicine request)
        {
            var result = _medicinesManager.SaveNewMedicine(request);
            return new OkObjectResult(result);
        }

        // PUT: api/Medicines/5
        [HttpPut("{id}")]
        public ActionResult UpdateMedicine(int id, [FromBody] Medicine request)
        {
            var result = _medicinesManager.UpdateMedicine(id, request);
            return new OkObjectResult(result);
        }
    }
}
