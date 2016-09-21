using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using UniversitySystem.Entities;
using System.Configuration;

namespace UniversitySystem.Data
{
  public class DataEstudiante
    {
        private string connectionString = Properties.Settings.Default.ConnectionString;              




        private List<Estudiante> list;

        public static object ConfigurationSetting { get; private set; }

        public DataEstudiante()
        {
            
           
        }


        public List<Estudiante> ObtenerTodos()
        {
            list = new List<Estudiante>();
            string query = "SELECT * FROM [Estudiante]";
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

        public void Insertar(Estudiante student)
        {
            String query = "INSERT INTO[Estudiante](Carnet,Nombre,Apellido,Edad,Sexo)" + "VALUES(@carnet,@nombre,@apellido,@edad,@sexo)";

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


        public void Actualizar(Estudiante student)

        {
            String query = "UPDATE[Estudiante] SET Carnet=@carnet,Nombre=@nombre,Apellido=@apellido,Edad=@edad,Sexo=@sexo ID=@id";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@carnet", student.Carnet);
            command.Parameters.AddWithValue("@nombre", student.Nombre);
            command.Parameters.AddWithValue("@apellido", student.Apellido);
            command.Parameters.AddWithValue("@edad", student.Edad);
            command.Parameters.AddWithValue("@sexo", student.Sexo);
            command.Parameters.AddWithValue("@id", student.Id);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();



        }


        public void Eliminar(int id)
        {

            string query = "DELETE FROM [Estudiante] WHERE id=@id";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("id", id);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();




        }


    }



}
