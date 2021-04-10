using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class BlockedUser:ICar
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Byte[] PasswordSalt { get; set; }
        public Byte[] PasswordHash { get; set; }
        public DateTime? BlockingDate { get; set; }
    }
}
