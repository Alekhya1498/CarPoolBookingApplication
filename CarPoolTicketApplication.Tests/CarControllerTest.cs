using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using CarPoolTicket.DataAccess;
using CarPoolTicket.DataAccess.Infrastructure;
using CarPoolTicket.DataAccess.Repositories;
using CarPoolBooking.Models;
using CarPoolBooking.Models.ViewModels;
using CarPoolBookingApplication.Areas.Admin.Controllers;
using Moq;

namespace CarPoolTicketApplication.Tests
{
    [TestClass()]
    public class CarControllerTest
    {
        private readonly CarController carController;
        private readonly IUnitOfWork unitOfWork;
        private readonly Mock<ApplicationDbContext> _context;
        private readonly DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptions<ApplicationDbContext>();

        public CarControllerTest()
        {
            _context = TransactionalEfContext.Get();
            var mockDbSet = Substitute.For<DbSet<Car>, IQueryable<Car>>();
            unitOfWork = new UnitOfWork(_context.Object);
            carController = new CarController(unitOfWork);
        }

        [TestMethod()]
        public void GetAllCarTests()
        {
            var res = carController.GetAllCar();
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void Create_WithIdZero_ReturnsResponse()
        {
            var res = carController.CreateUpdate(0);
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void Update_WithValidId_ReturnsResponse()
        {
            var res = carController.CreateUpdate(1);
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void Create_WithValidCarVM_ReturnsResponse()
        {
            var res = carController.CreateUpdate(new CarVm() { Car = new Car() { Id = 0, CarNumber = "125", SeatCapacity = "30" } });
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void Update_WithValidCarVM_ReturnsResponse()
        {
            var res = carController.CreateUpdate(new CarVm() { Car = new Car() { Id = 6, CarNumber = "1525", SeatCapacity = "20" } });
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var res = carController.Delete(2);
            Assert.IsNotNull(res);
        }
    }
}
