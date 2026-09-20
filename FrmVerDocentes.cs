using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV262526_Desafio02
{
    public partial class FrmVerDocentes : Form
    {
        public FrmVerDocentes()
        {
            InitializeComponent();
        }

        private void FrmVerDocentes_Load(object sender, EventArgs e)
        {
            try
            {
                // Crea las columnas de la tabla
                dgvDocentes.Columns.Clear();
                dgvDocentes.Columns.Add("colNombres", "Nombres");
                dgvDocentes.Columns.Add("colApellidos", "Apellidos");
                dgvDocentes.Columns.Add("colFecha", "Fecha de nacimiento");
                dgvDocentes.Columns.Add("colSexo", "Sexo");
                dgvDocentes.Columns.Add("colProfesion", "Profesión");
                dgvDocentes.Columns.Add("colAsignatura", "Asignatura");

                // Recorre el arreglo y agrega una fila por cada docente
                for (int i = 0; i < Almacen.TotalDocentes; i++)
                {
                    Docente d = Almacen.Docentes[i];
                    dgvDocentes.Rows.Add(d.Nombres, d.Apellidos,
                                         d.FechaNacimiento.ToShortDateString(),
                                         d.Sexo, d.Profesion, d.Asignatura);
                }

                if (Almacen.TotalDocentes == 0)
                    MessageBox.Show("No hay docentes registrados.", "Información");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los docentes: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}