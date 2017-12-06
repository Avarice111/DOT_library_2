using System;
using Notification;

namespace Dot.Library.Database
{
    public class User
    {
        public int ID {get; set;}

        public string FirstName {get; set;}
        public string LastName {get; set;}

        public string Login {get; set;}

        public string Password {get; set;}

        public Address Address {get; set;} 
    }
}