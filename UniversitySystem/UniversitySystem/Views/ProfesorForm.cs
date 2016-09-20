using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversitySystem.Data;
using UniversitySystem.Entities;

namespace UniversitySystem.Views
{
    public partial class ProfesorForm : Form
    {
        private DataTable table;
        private DataProfesores data;

        public ProfesorForm()
        {
            InitializeComponent();

            table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Titulo");
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Edad");
            table.Columns.Add("Sexo");

            data = new DataProfesores();
            LoadTable();
        }

        public void LoadTable()
        {

            List<Profesor> profesor = data.ObtenerTodosProfesor();

            foreach (Profesor profesores in profesor)
            {

                DataRow row = table.NewRow();

                row["Id"] = profesores.Id;
                row["Nombre"] = profesores.Nombre;
                row["Apellido"] = profesores.Apellido;
                row["Titulo"] = profesores.Titulo;
                row["Edad"] = profesores.Edad;
                row["Sexo"] = profesores.Sexo;

                table.Rows.Add(row);



            }

            dgvProfesor.DataSource = table;
        }


        public void AddProfesor(Profesor profesor)
        {

            data.Insertar(profesor);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddProfesor addForm = new AddProfesor();

            addForm.ShowDialog(this);
        }
    }
}
