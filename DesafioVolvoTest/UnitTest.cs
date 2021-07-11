using DesafioVolvo;
using DesafioVolvo.BLL.Interface;
using DesafioVolvo.BLL.Service;
using DesafioVolvo.Controllers;
using DesafioVolvo.DAO.Interface;
using DesafioVolvo.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DesafioVolvoTest
{
    public class UnitTest
    {
        public Mock<ITruckService> mock = new Mock<ITruckService>();
        private readonly ITruckRepository _truckRepository;
        private readonly Mock<ITruckService> _mockService;

        public UnitTest()
        {
            _mockService = new Mock<ITruckService>();
        }

        [Fact]
        public void Test_LoadTruckModels()
        {
            List<TruckModel> list = new List<TruckModel>();

            var item = new TruckModel();
            item.ModelName = "FM";
            item.TruckModelId = 1;

            list.Add(item);

            mock.Setup(p => p.LoadTruckModels()).Returns(list);
            TruckController emp = new TruckController(mock.Object);
            var result = emp.LoadTruckModels();
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(2010)]
        [InlineData(2021)]
        public void Test_Mantain_ManufactureYear(int manufactureYear)
        {
            TruckService emp = new TruckService(_truckRepository);
            var x = emp.IsValidManufactureYear(manufactureYear);
            Assert.True(x.IsValid, x.ErrorMessage);
        }

        [Theory]
        [InlineData(2020)]
        [InlineData(2021)]
        [InlineData(2022)]
        public void Test_Mantain_ModelYear(int modelYear)
        {
            TruckService emp = new TruckService(_truckRepository);
            var x = emp.IsValidModelYear(modelYear);
            Assert.True(x.IsValid, x.ErrorMessage);
        }

        [Fact]
        public void Test_Mantain_AllowedModels()
        {
            var result = new ResultView()
            {
                IsValid = true
            };

            var truck = new Truck
            {
                TruckModelId = 1,
                TruckName = "Teste",
                ManufactureYear = 2021,
                ModelYear = 2021
            };

            List<TruckModel> listModels = new List<TruckModel>
            {
               new TruckModel { ModelName = "FM", TruckModelId = 1 },
               new TruckModel { ModelName = "FH", TruckModelId = 2 },
               new TruckModel { ModelName = "FMX", TruckModelId = 3 },
               new TruckModel { ModelName = "VM", TruckModelId = 4 }
            };

            var res = new ResultView();
            var validModels = listModels.Find(x => x.TruckModelId == truck.TruckModelId);
            if (validModels is null)
            {
                res.IsValid = false;
                res.ErrorMessage = "O modelo do caminhão deve: FH ou FM";
            }
            else
                res.IsValid = true;

            Assert.True(res.IsValid, res.ErrorMessage);
        }
    }
}