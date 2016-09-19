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
    public partial class AddProfesor : Form
    {
        public AddProfesor()
        {
            InitializeComponent();
        }

        private void AddProfesor_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Profesor profesor = new Profesor();
            profesor.Titulo = tbxTitulo.Text;
            profesor.Nombre = tbxNombre.Text;
            profesor.Apellido = tbxApellido.Text;
            profesor.Edad = Convert.ToInt32(tbxEdad.Text);
            profesor.Sexo = ((String)cbxSexo.SelectedItem).Substring(0, 1);

            ProfesorForm owner = (ProfesorForm)this.Owner;
            owner.AddProfesor(profesor);

            this.Close();


        }
    }
}
