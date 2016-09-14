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

        }


        private void StudentsForm_Load(object sender, EventArgs e)
        {

            
                

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddStudent addForm = new AddStudent();

            addForm.ShowDialog(this);
        }
    }
}
