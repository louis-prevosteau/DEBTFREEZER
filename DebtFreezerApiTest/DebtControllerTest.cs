using DebtFreezerApi.Controllers;
using DebtFreezerApi.Data;
using DebtFreezerApi.Dtos;
using DebtFreezerApi.Models;
using DebtFreezerApi.Repositories;
using DebtFreezerApi.Repository;
using DebtFreezerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Text;


namespace DebtFreezerApiTest
{
    [TestClass]
    internal class DebtControllerTest
    {

        [TestMethod]

        public void  TestCreate_invalid_shouldBe_BadRequest()

        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);
            IRepository<Debt> debtRepository = new DebtsRepository(context);
            IUSerRepository userRepository = new UserRepository(context);
            IDebtService service = new DebtService(debtRepository, userRepository);
            DebtController debtCtrl = new DebtController(service);

            var dto = new CreateDebtDto
            {
                DueDate = DateTime.Now,
                InterestRate = 200,
                OriginalAmount = 3000,
                RemainingAmount = 2000,
                Type = DebtType.CREDIT_CARD,
                UserId = 1
            };
            var res =   debtCtrl.CreateAsync(dto);
            //int statusCode = GetStatusCode(res);

            Assert.IsInstanceOfType(res.Result, typeof(BadRequestObjectResult));

        }


        public void TestCreate_MontantNegatif_shouldBe_BadRequest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);
            IRepository<Debt> debtRepository = new DebtsRepository(context);
            IUSerRepository userRepository = new UserRepository(context);
            IDebtService service = new DebtService(debtRepository, userRepository);
            DebtController debtCtrl = new DebtController(service);

            var dto = new CreateDebtDto
            {
                DueDate = DateTime.Now,
                InterestRate = 200,
                OriginalAmount = -5000,
                RemainingAmount = 2000,
                Type = DebtType.CREDIT_CARD,
                UserId = 1
            };
            var res = debtCtrl.CreateAsync(dto);
            //int statusCode = GetStatusCode(res);

            Assert.IsInstanceOfType(res.Result, typeof(BadRequestObjectResult));

        }

        public  async Task GetByIdAsync_ShouldReturnOk_WithDebt()
        {
            // Arrange
            var mockService = new Mock<IDebtService>();
            SetupGetById(mockService, 1);

            var controller = new DebtController(mockService.Object);

            var crtl = new DebtController(mockService.Object);



            // Act
            var result = await controller.GetByIdAsync(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));



        }


        private void SetupGetById(Mock<IDebtService> mockService, int id)
        {
            mockService.Setup(s => s.GetByIdAsync(id))
                       .ReturnsAsync(new DebtDto { Id = id });

          


        }






    }


}

