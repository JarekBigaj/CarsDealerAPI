using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsDealerApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public required string Email {get; set;} = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public List<TestDrive>? TestDrives { get; set; }
        public List<Offer>? Offers { get; set; }
        public List<Purchase>? Purchases { get; set; }
    }
}