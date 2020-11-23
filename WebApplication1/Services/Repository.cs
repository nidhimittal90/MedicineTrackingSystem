using MedicinesTracking.Models;
using MedicinesTracking.Services.Interface;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MedicinesTracking.Services
{
    public class Repository : IRepository
    {
        public Medicine AddMedicine(Medicine medicine)
        {
            var filePath = @"Services\Records.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            var medincineList = JsonConvert.DeserializeObject<MedicineList>(jsonData)
                                  ?? new MedicineList();
            int id = medincineList.Medicines.Count() + 1;
            medicine.Id = id;
            medincineList.Medicines.Add(medicine);
            jsonData = JsonConvert.SerializeObject(medincineList);
            System.IO.File.WriteAllText(filePath, jsonData);
            return medicine;
        }

        public MedicineList GetMedicineList()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"Services\Records.json");
            var medicines = JsonConvert.DeserializeObject<MedicineList>(json);
            return medicines;
        }

        public Medicine UpdateMedicine(int id, Medicine request)
        {
            var filePath = @"Services\Records.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            var medincineList = JsonConvert.DeserializeObject<MedicineList>(jsonData)
                                  ?? new MedicineList();
            foreach( var medicine in  medincineList.Medicines.Where(x=>x.Id == id))
            {
                medicine.BrandName = string.IsNullOrEmpty( request.BrandName)? request.BrandName : medicine.BrandName;
                medicine.MedicineName = string.IsNullOrEmpty(request.MedicineName) ? request.MedicineName : medicine.MedicineName;
                medicine.Quantity = request.Quantity <= 0 ? request.Quantity : medicine.Quantity;
                medicine.Price = request.Price<=0 ? request.Price : medicine.Price;
                medicine.Notes = string.IsNullOrEmpty(request.Notes) ? request.Notes : medicine.Notes;
            }
           
            jsonData = JsonConvert.SerializeObject(medincineList);
            System.IO.File.WriteAllText(filePath, jsonData);
            return request;
        }
    }
}
