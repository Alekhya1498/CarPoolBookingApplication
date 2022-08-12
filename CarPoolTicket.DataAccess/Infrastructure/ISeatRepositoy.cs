using CarPoolTicket.DataAccess.Infrastructure;
using CarPoolBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolTicket.DataAccess.Infrastructure
{
    public interface ISeatRepository : IGenricRepository<SeatDetails>
    {
        void Update(SeatDetails seat);
    }
}
