using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsDealerApi.Model
{
    public class DealerAccount
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public List<Car>? Cars { get; set; }
    }
}