using CarPoolBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolTicket.DataAccess.Infrastructure
{
    public interface ICarRepository : IGenricRepository<Car>
    {
        void Update(Car car);
    }
}
