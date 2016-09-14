namespace UniversitySystem.Views
{
    partial class ProfesorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvProfesor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProfesor
            // 
            this.dgvProfesor.AllowUserToAddRows = false;
            this.dgvProfesor.AllowUserToDeleteRows = false;
            this.dgvProfesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfesor.Location = new System.Drawing.Point(28, 78);
            this.dgvProfesor.Name = "dgvProfesor";
            this.dgvProfesor.ReadOnly = true;
            this.dgvProfesor.Size = new System.Drawing.Size(523, 233);
            this.dgvProfesor.TabIndex = 0;
            // 
            // ProfesorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 323);
            this.Controls.Add(this.dgvProfesor);
            this.Name = "ProfesorForm";
            this.Text = "ProfesorForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProfesor;
    }
}