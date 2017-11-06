using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSP_Application.DataObjects
{
    public class Objects
    {
    }

    public class User
    {
        public string Username { get; set; }
        public int IDUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
    }
}