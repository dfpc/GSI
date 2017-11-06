using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BSP_Application.DataObjects
{
    public class DataBaseConnect : DbContext
    {
        public DataBaseConnect() : base("BSP_Application")
        {

        }
    }
}