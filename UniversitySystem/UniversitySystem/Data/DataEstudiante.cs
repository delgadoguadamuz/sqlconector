using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using UniversitySystem.Entities;

namespace UniversitySystem.Data
{
  public class DataEstudiante
    {
       private string connectionString =
                "Data Source=TLCOYO-LOANER7\\SQLEXPRESS;Initial Catalog=Universidad;"
                + "Integrated Security=true";



        private List<Estudiante> list;

        public DataEstudiante()
        {
            
           
        }


        public List<Estudiante> ObtenerTodos()
        {
            list = new List<Estudiante>();
            string query = "SELECT * FROM [Estuduante]";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Estudiante estudiante = new Estudiante();

                estudiante.Id = (int)reader["Id"];
                estudiante.Nombre = (string)reader["Nombre"];
                estudiante.Apellido = (string)reader["Apellido"];
                estudiante.Carnet = (string)reader["Carnet"];
                estudiante.Edad = (int)reader["Edad"];
                estudiante.Sexo = (string)reader["Sexo"];

                list.Add(estudiante);
            }

            reader.Close();
            connection.Close();

            return list;
        }



    }



}
