using System;

namespace UsersControl
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public int Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }

        public override string ToString()
        {
            return Login;
        }
    }
}
