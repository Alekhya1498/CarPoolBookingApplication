using CarPoolTicket.DataAccess.Infrastructure;
using CarPoolBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoolPoolTicket.DataAccess.Repositories;
using CarPoolTicket.DataAccess;

namespace CarPoolTicket.DataAccess.Repositories
{
    public class CarRepository : GenricRepository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Car car)
        {
            var CarFromDb = _context.Car.FirstOrDefault(x => x.Id == car.Id);
            if (CarFromDb != null)
            {
                CarFromDb.CarNumber = car.CarNumber;
                CarFromDb.SeatCapacity = car.SeatCapacity;
            }
        }
    }
}
