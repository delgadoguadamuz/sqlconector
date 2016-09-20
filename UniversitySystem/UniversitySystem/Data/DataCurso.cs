using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Entities;

namespace UniversitySystem.Data
{
    class DataCurso
    {

        private string connectionString = Properties.Settings.Default.ConnectionString;



        private List<Curso> list;

        public DataCurso()
        {


        }


        public List<Curso> ObtenerTodos()
        {
            list = new List<Curso>();
            string query = "SELECT * FROM [Curso]";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Curso curso = new Curso();


                curso.Nombre = (string)reader["Nombre"];
                curso.Sigla = (string)reader["Sigla"];
                curso.IdProfesor = (int)reader["IdProfesor"];
                curso.CupoMax = (int)reader["CupoMax"];


                list.Add(curso);
            }

            reader.Close();
            connection.Close();

            return list;
        }

        public void Insertar(Curso curso)
        {
            String query = "INSERT INTO[Curso](IdProfesor,Nombre,Sigla,CupoMax)" +
                            "VALUES(@idprofesor,@nombre,@sigla,@cupomax)";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@nombre", curso.Nombre);
            command.Parameters.AddWithValue("@sigla", curso.Sigla);
            command.Parameters.AddWithValue("@cupomax", curso.CupoMax);
            command.Parameters.AddWithValue("@idprofesor", curso.IdProfesor);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();


        }
    }
}