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
    class DataProfesores
    {
        private string connectionString = Properties.Settings.Default.ConnectionString;



        private List<Profesor> list;

        public DataProfesores()
        {


        }


        public List<Profesor> ObtenerTodosProfesor()
        {
            list = new List<Profesor>();
            string query = "SELECT * FROM [Profesor]";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Profesor profesor = new Profesor();

                profesor.Id = (int)reader["Id"];
                profesor.Nombre = (string)reader["Nombre"];
                profesor.Apellido = (string)reader["Apellido"];
                profesor.Titulo = (string)reader["Titulo"];
                profesor.Edad = (int)reader["Edad"];
                profesor.Sexo = (string)reader["Sexo"];

                list.Add(profesor);
            }

            reader.Close();
            connection.Close();

            return list;

        }

        public void Insertar(Profesor profesor)
        {
            String query = "INSERT INTO[Profesor](Titulo,Nombre,Apellido,Edad,Sexo)" +
                            "VALUES(@titulo,@nombre,@apellido,@edad,@sexo)";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@titulo", profesor.Titulo);
            command.Parameters.AddWithValue("@nombre", profesor.Nombre);
            command.Parameters.AddWithValue("@apellido", profesor.Apellido);
            command.Parameters.AddWithValue("@edad", profesor.Edad);
            command.Parameters.AddWithValue("@sexo", profesor.Sexo);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void Actualizar(Profesor profesor)

        {
            String query = "UPDATE [Profesor] SET Titulo=@titulo,Nombre=@nombre,Apellido=@apellido,Edad=@edad,Sexo=@sexo WHERE Id=@id";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@titulo", profesor.Titulo);
            command.Parameters.AddWithValue("@nombre", profesor.Nombre);
            command.Parameters.AddWithValue("@apellido", profesor.Apellido);
            command.Parameters.AddWithValue("@edad", profesor.Edad);
            command.Parameters.AddWithValue("@sexo", profesor.Sexo);
            command.Parameters.AddWithValue("@id", profesor.Id);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();



        }


        public void Eliminar(int id)
        {

            string query = "DELETE FROM [Profesor] WHERE id=@id";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("id", id);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();




        }


    }

}