using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSP_Application.DataObjects
{
    public class AdicionarRegistos
    {
        public static void AddProject()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("exec spCreateProject @Nome ={0}, @Descricao={1}", "teste", "descrição teste");
            }
        }
    }
}