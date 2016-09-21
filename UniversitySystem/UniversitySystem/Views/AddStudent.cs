using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversitySystem.Entities;

namespace UniversitySystem.Views
{
    public partial class AddStudent : Form
    {

        private Estudiante student;

        public AddStudent()
        {
            student = new Estudiante();

            InitializeComponent();

        }

        public AddStudent(Estudiante student)
        {

            this.student = student;

            InitializeComponent();

            tbxNombre.Text = student.Nombre;
            tbxApellido.Text = student.Apellido;
            tbxCarnet.Text = student.Carnet;
            tbxEdad.Text = student.Edad.ToString();
            

            if (student.Sexo == "M")
            {

                cbxSexo.Text = "Masculino";

            }
            if (student.Sexo == "F") {

                cbxSexo.Text = "Femenino";

            }


            
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (student.Id > 0)
            {
                student.Carnet = tbxCarnet.Text;
                student.Nombre = tbxNombre.Text;
                student.Apellido = tbxApellido.Text;
                student.Edad = Convert.ToInt32(tbxEdad.Text);
                student.Sexo = ((String)cbxSexo.SelectedItem).Substring(0, 1);
                StudentsForm owner = (StudentsForm)this.Owner;
                owner.EditStudents(student);
            }
            else
            {
                student = new Estudiante();
                student.Carnet = tbxCarnet.Text;
                student.Nombre = tbxNombre.Text;
                student.Apellido = tbxApellido.Text;
                student.Edad = Convert.ToInt32(tbxEdad.Text);
                student.Sexo = ((String)cbxSexo.SelectedItem).Substring(0, 1);

                StudentsForm owner = (StudentsForm)this.Owner;
                owner.AddStudents(student);
            }
            this.Close();
            
        }

        private void tbxNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
