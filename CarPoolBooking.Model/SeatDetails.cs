using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPoolBooking.Models
{
    public class SeatDetails
    {
        public int Id { get; set; }

        public int SeatNo { get; set; }

        public string Description { get; set; }

        public int BusId { get; set; }

        public Car Car { get; set; }
    }
}
