using MedicinesUI.Model;
using MedicinesUI.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MedicinesUI.Services
{
    public class MedicineRepository:IMedicineRepository
    {
        private string filePath = @"Services\Records.json";
        public MedicineRepository()
        {

        }
        public MedicineRepository(string path)
        {
            filePath = path;
        }
        public Medicine AddMedicine(Medicine medicine)
        {
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

        public List<Medicine> GetMedicineList()
        {
            //var webClient = new WebClient();
            //var json = webClient.DownloadString(@"Services\Records.json");
            //var medicines = JsonConvert.DeserializeObject<MedicineList>(json);
            var jsonData = System.IO.File.ReadAllText(filePath);
            var medicines = JsonConvert.DeserializeObject<MedicineList>(jsonData)
                                  ?? new MedicineList();
            return medicines.Medicines;
        }

        public Medicine UpdateMedicine(int id, string notes)
        {
            var jsonData = System.IO.File.ReadAllText(filePath);
            var medicineList = JsonConvert.DeserializeObject<MedicineList>(jsonData)
                                  ?? new MedicineList();
            var medicine = medicineList.Medicines.Where(x => x.Id == id).FirstOrDefault();

            //foreach (var medicine in medincineList.Medicines.Where(x => x.Id == id))
            //{
             
                medicine.Notes = notes;
           // }

            jsonData = JsonConvert.SerializeObject(medicineList);
            System.IO.File.WriteAllText(filePath, jsonData);
            return medicine;
        }
    }
}
