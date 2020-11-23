using MedicinesUI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using AutoFixture;
using System;
using System.Collections.Generic;
using System.Text;
using MedicinesUI.Model;
using AutoFixture.Kernel;

namespace MedicineTrackingTest.Service
{
    [TestClass]
    public class MedicineRepositoryTest
    {
        private MedicineRepository _repository;
        private Fixture _fixture;
        public MedicineRepositoryTest()
        {
            _fixture = new Fixture();
            _repository = new MedicineRepository(@"Service\TestRecords.json");
        }

        [TestMethod]
        public void GetMedicineList()
        {
            var response = _repository.GetMedicineList();
            response.ShouldNotBeNull();

        }

        [TestMethod]
        public void AddNewMedicine()
        {
            var medicine = _fixture.Build<Medicine>().Create();
            int previousRecords = _repository.GetMedicineList().Count;
            var response = _repository.AddMedicine(medicine);
            int recordsAfterSave = _repository.GetMedicineList().Count;

            response.ShouldNotBeNull();
            Assert.AreEqual(previousRecords + 1, recordsAfterSave);
        }

        [TestMethod]
        public void UpdateMedicine()
        {
            var updatedNotes = "Updated Notes";
            var response = _repository.UpdateMedicine(2,updatedNotes);
            response.ShouldNotBeNull();
            Assert.AreEqual(response.Notes, updatedNotes);
        }
    }
}
