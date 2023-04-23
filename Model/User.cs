using System;
using System.Collections.Generic;

namespace robot_controller_api.Model
{
    public  class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly ModifiedDate { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
    }
}
