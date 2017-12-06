using System;

namespace Dot.Library.Database
{
    public class Notification
    {
        public string Author {get; set;}
        public string Date {get; set;}
        public string Text {get; set;}
        public User User {get; set;}
    }
} 