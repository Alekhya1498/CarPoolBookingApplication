using CarPoolTicket.DataAccess.Infrastructure;
using CarPoolTicket.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            BusRepository = new CarRepository(_context);
            SeatRepository = new SeatRepositoy(_context);
        }

        public ICarRepository BusRepository { get; private set; }

        public ISeatRepository SeatRepository { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
