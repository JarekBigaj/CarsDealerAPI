using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsDealerApi.Model
{
    public class TestDrive
    {
        public int Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public User? User { get; set; }
        public Car? Car { get; set; }
    }
}