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
    public partial class FrmVerAlumnos : Form
    {
        public FrmVerAlumnos()
        {
            InitializeComponent();

            // Conectamos el boton desde el codigo
            btnCerrar.Click += btnCerrar_Click;

            CargarTabla();
        }

        // Crea las columnas y llena la tabla
        private void CargarTabla()
        {
            try
            {
                dgvAlumnos.Columns.Clear();
                dgvAlumnos.Columns.Add("colNombres", "Nombres");
                dgvAlumnos.Columns.Add("colApellidos", "Apellidos");
                dgvAlumnos.Columns.Add("colFecha", "Fecha de nacimiento");
                dgvAlumnos.Columns.Add("colSexo", "Sexo");
                dgvAlumnos.Columns.Add("colCarrera", "Carrera");
                dgvAlumnos.Columns.Add("colCarnet", "Carnet");

                // Recorre el arreglo y agrega una fila por cada alumno
                for (int i = 0; i < Almacen.TotalAlumnos; i++)
                {
                    Alumno a = Almacen.Alumnos[i];
                    dgvAlumnos.Rows.Add(a.Nombres, a.Apellidos,
                                        a.FechaNacimiento.ToShortDateString(),
                                        a.Sexo, a.Carrera, a.Carnet);
                }

                if (Almacen.TotalAlumnos == 0)
                    MessageBox.Show("No hay alumnos registrados.", "Información");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los alumnos: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}