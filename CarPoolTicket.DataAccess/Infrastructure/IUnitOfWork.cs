using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolTicket.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }

        ISeatRepository SeatRepository { get; }

        void Save();
    }
}
