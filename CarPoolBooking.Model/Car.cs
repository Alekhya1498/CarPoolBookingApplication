using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPoolBooking.Models
{
    public class Car
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CarNumber { get; set; }

        public string SeatCapacity { get; set; }
    }
}
