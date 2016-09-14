﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using UniversitySystem.Entities;

namespace UniversitySystem.Data
{
    class DataProfesores
    {
        private string connectionString =
                "Data Source=TLCOYO-LOANER7\\SQLEXPRESS;Initial Catalog=Universidad;"
                + "Integrated Security=true";



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
    }

}