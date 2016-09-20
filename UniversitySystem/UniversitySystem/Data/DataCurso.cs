using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Entities;

namespace UniversitySystem.Data
{
    class DataCurso
    {

        private string connectionString =
               "Data Source=TLCOYO-LOANER7\\SQLEXPRESS;Initial Catalog=Universidad;"
               + "Integrated Security=true";



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

                estudiante.Id = (int)reader["Id"];
                estudiante.Nombre = (string)reader["Nombre"];
                estudiante.Apellido = (string)reader["Apellido"];
                estudiante.Carnet = (string)reader["Carnet"];
                estudiante.Edad = (int)reader["Edad"];
                estudiante.Sexo = (string)reader["Sexo"];

                list.Add(curso);
            }

            reader.Close();
            connection.Close();

            return list;
        }

        public void Insertar(Curso curso)
        {
            String query = "INSERT INTO[Curso](Carnet,Nombre,Apellido,Edad,Sexo)" +
                            "VALUES(@carnet,@nombre,@apellido,@edad,@sexo)";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@carnet", student.Carnet);
            command.Parameters.AddWithValue("@nombre", student.Nombre);
            command.Parameters.AddWithValue("@apellido", student.Apellido);
            command.Parameters.AddWithValue("@edad", student.Edad);
            command.Parameters.AddWithValue("@sexo", student.Sexo);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();


        }
    }
