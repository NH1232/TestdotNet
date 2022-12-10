using System;
using System.Collections.Generic;

namespace RegisterUser.DataDB
{
    public partial class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Otp { get; set; }
        public byte? Confirm { get; set; }
    }
}
