using MedicinesUI.Manager.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoFixture;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using MedicinesUI.Model;
using MedicinesUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicineTrackingTest.Controller
{
    [TestClass]
    public class MedicineControllerTest
    {
        private Mock<IMedicinesManager> _medicinesManager;
        private Fixture _fixture;
        private MedicineController _controller;
        public MedicineControllerTest()
        {
            _fixture = new Fixture();
            _medicinesManager = new Mock<IMedicinesManager>();
            _controller = new MedicineController(_medicinesManager.Object);
        }

        [TestMethod]
        public void GetMedicineTest()
        {
            var medicine = _fixture.Build<Medicine>().Create();
            var medicineList = new List<Medicine>();
            medicineList.Add(medicine);
            _medicinesManager.Setup(s => s.GetMedicines()).Returns(medicineList);
            var response = _controller.Get();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void AddMedicineTest()
        {
            var medicine = _fixture.Build<Medicine>().Create();
            _medicinesManager.Setup(s => s.SaveNewMedicine(medicine)).Returns(medicine);
            var response = _controller.AddMedicine(medicine);
            response.ShouldBeOfType(typeof(OkObjectResult));
            var result = response as OkObjectResult;
            result.StatusCode.HasValue.ShouldBeTrue();
            result.StatusCode.Value.ShouldBe((int)HttpStatusCode.OK);
        }
        [TestMethod]
        public void UpdateMedicineTest()
        {
            var medicine = _fixture.Build<Medicine>().Create();
            int id = 1;
            string updatedNotes = "updated notes";
            medicine.Notes = updatedNotes;
            _medicinesManager.Setup(s => s.UpdateMedicine(id, updatedNotes)).Returns(medicine);
            var response = _controller.UpdateMedicine(id, updatedNotes);
            response.ShouldBeOfType(typeof(OkObjectResult));
            var result = response as OkObjectResult;
            result.StatusCode.HasValue.ShouldBeTrue();
            result.StatusCode.Value.ShouldBe((int)HttpStatusCode.OK);
        }
    }
}
