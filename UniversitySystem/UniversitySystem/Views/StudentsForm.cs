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
        }

        public void LoadTable()
        {

          List<Estudiante> students = data.ObtenerTodos();

            foreach(Estudiante student in students)
            {

                DataRow row = table.NewRow();

                row["Id"] = student.Id;
                row["Nombre"] = student.Id;
                row["Apellido"] = student.Id;
                row["Carnet"] = student.Id;
                row["Edad"] = student.Id;
                row["Sexo"] = student.Id;

                table.Rows.Add(row);

            }

            

        }



        private void StudentsForm_Load(object sender, EventArgs e)
        {

            
                

        }
    }
}
