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
    public partial class StudentsForm : Form
    {
        private DataTable table;
        private DataEstudiante data;
        


        public StudentsForm()
        {
            InitializeComponent();

            table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Carnet");
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Edad");
            table.Columns.Add("Sexo");

            data = new DataEstudiante();
            LoadTable();
        }

        public void LoadTable()
        {
            table.Clear();

            List<Estudiante> students = data.ObtenerTodos();

            foreach(Estudiante student in students)
            {

                DataRow row = table.NewRow();

                row["Id"] = student.Id;
                row["Nombre"] = student.Nombre;
                row["Apellido"] = student.Apellido;
                row["Carnet"] = student.Carnet;
                row["Edad"] = student.Edad;
                row["Sexo"] = student.Sexo;

                table.Rows.Add(row);

               

            }

            dgwStudents.DataSource = table;

        }

        public void AddStudents(Estudiante student)
        {

            data.Insertar(student);
            LoadTable();
        }


        private void StudentsForm_Load(object sender, EventArgs e)
        {

            
                

        }

        public void EditStudents(Estudiante student)
        {

            data.Actualizar(student);
            LoadTable();


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddStudent addForm = new AddStudent();

            addForm.ShowDialog(this);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgwStudents.SelectedRows.Count > 0)
            {

                DataGridViewSelectedRowCollection rows = dgwStudents.SelectedRows;

                DataGridViewRow row = rows[0];

                Estudiante student = new Estudiante();
                student.Id = Convert.ToInt32(row.Cells["id"].Value);
                student.Nombre = (String)row.Cells["nombre"].Value;
                student.Carnet = (String)row.Cells["carnet"].Value;
                student.Apellido = (String)row.Cells["apellido"].Value;
                student.Edad = Convert.ToInt32(row.Cells["edad"].Value);
                student.Sexo = (string)row.Cells["sexo"].Value;

                AddStudent addForm = new AddStudent(student);
                addForm.ShowDialog(this);


            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection rows = dgwStudents.SelectedRows;

            DataGridViewRow row = rows[0];
            Estudiante student = new Estudiante();
            student.Id = Convert.ToInt32(row.Cells["id"].Value);

            DataEstudiante data = new DataEstudiante();

            data.Eliminar(student.Id);

            LoadTable();

        }
    }
}
