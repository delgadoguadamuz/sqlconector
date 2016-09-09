using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UniversitySystem.Data
{
  public class DataEstudiante
    {
       private string connectionString =
                "Data Source=TLCOYO-LOANER7\\SQLEXPRESS;Initial Catalog=Universidad;"
                + "Integrated Security=true";



        private DataTable table;

        public DataEstudiante()
        {
            table = new DataTable();
            
        }


        public DataTable ObtenerTodos()
        {
            return null;
        }



    }



}
