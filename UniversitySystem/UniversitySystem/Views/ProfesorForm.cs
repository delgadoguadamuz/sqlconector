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
            LoadTable();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddProfesor addForm = new AddProfesor();

            addForm.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvProfesor.SelectedRows.Count > 0)
            {

                DataGridViewSelectedRowCollection rows = dgvProfesor.SelectedRows;

                DataGridViewRow row = rows[0];

                Profesor profesor = new Profesor();
                profesor.Id = Convert.ToInt32(row.Cells["id"].Value);
                profesor.Nombre = (String)row.Cells["nombre"].Value;
                profesor.Titulo = (String)row.Cells["carnet"].Value;
                profesor.Apellido = (String)row.Cells["apellido"].Value;
                profesor.Edad = Convert.ToInt32(row.Cells["edad"].Value);
                profesor.Sexo = (string)row.Cells["sexo"].Value;

                AddProfesor addForm = new AddProfesor(profesor);
                addForm.ShowDialog(this);


            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection rows = dgvProfesor.SelectedRows;

            DataGridViewRow row = rows[0];
            Profesor profesor = new Profesor();
            profesor.Id = Convert.ToInt32(row.Cells["id"].Value);

            DataEstudiante data = new DataEstudiante();

            data.Eliminar(profesor.Id);

            LoadTable();
        }
    }
}
