using CarPoolTicket.DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = CarPoolBooking.Models;

namespace CarPoolTicketApplication.Tests
{
    public static class TransactionalEfContext
    {
        public static List<EF.Car> _carList;
        public static List<EF.SeatDetails> _seatDetail;

        public static Mock<ApplicationDbContext> Get()
        {
            var context = new Mock<ApplicationDbContext> { CallBase = true };

            _carList = new List<EF.Car>()
            {
                new EF.Car()
                {
                    Id = 1,
                    CarNumber = "123",
                    SeatCapacity = "20"
                },
                new EF.Car()
                {
                    Id = 1,
                    CarNumber = "456",
                    SeatCapacity = "30"
                },
                new EF.Car()
                {
                    Id = 1,
                    CarNumber = "789",
                    SeatCapacity = "10"
                },
                new EF.Car()
                {
                    Id = 1,
                    CarNumber = "478",
                    SeatCapacity = "10"
                },
                new EF.Car()
                {
                    Id = 1,
                    CarNumber = "897",
                    SeatCapacity = "25"
                },
                new EF.Car()
                {
                    Id = 1,
                    CarNumber = "478956",
                    SeatCapacity = "35"
                },
                new EF.Car()
                {
                    Id = 1,
                    CarNumber = "456",
                    SeatCapacity = "12"
                }
            };

            context.Setup(m => m.SaveChanges()).Returns(1).Verifiable();

            return context;
        }
    }
}
