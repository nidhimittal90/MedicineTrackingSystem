using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicinesUI.Manager.Interface;
using MedicinesUI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicinesUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicinesManager _medicinesManager;
        public MedicineController(IMedicinesManager medicinesManager)
        {
            _medicinesManager = medicinesManager;
        }

        // GET: api/Medicines

        [HttpGet]
        public IEnumerable<Medicine> Get()
        {
            var result = _medicinesManager.GetMedicines();
            return result;
        }

        [HttpPost("AddMedicine")]
        public ActionResult AddMedicine([FromBody] Medicine request)
        {
            var result = _medicinesManager.SaveNewMedicine(request);
            return new OkObjectResult(result);
        }

        [HttpPut("UpdateMedicine/{id}")]
        public ActionResult UpdateMedicine(int id, [FromBody]string notes)
        {
            var result = _medicinesManager.UpdateMedicine(id, notes);
            return new OkObjectResult(result);
        }
    }
}