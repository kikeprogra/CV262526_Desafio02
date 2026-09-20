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
    public partial class FrmEliminarAlumno : Form
    {
        public FrmEliminarAlumno()
        {
            InitializeComponent();

            btnEliminar.Click += btnEliminar_Click;
            btnCerrar.Click += btnCerrar_Click;

            CargarTabla();
        }

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

                MostrarAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los alumnos: " + ex.Message);
            }
        }

        private void MostrarAlumnos()
        {
            dgvAlumnos.Rows.Clear();
            for (int i = 0; i < Almacen.TotalAlumnos; i++)
            {
                Alumno a = Almacen.Alumnos[i];
                dgvAlumnos.Rows.Add(a.Nombres, a.Apellidos,
                                    a.FechaNacimiento.ToShortDateString(),
                                    a.Sexo, a.Carrera, a.Carnet);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Almacen.TotalAlumnos == 0)
                    throw new InvalidOperationException("No hay alumnos para eliminar.");

                if (dgvAlumnos.CurrentRow == null)
                    throw new ArgumentException("Seleccione un alumno de la tabla.");

                int posicion = dgvAlumnos.CurrentRow.Index;
                Alumno a = Almacen.Alumnos[posicion];

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar a " + a.Nombres + " " + a.Apellidos + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    Almacen.EliminarAlumno(posicion);
                    MostrarAlumnos();
                    MessageBox.Show("Alumno eliminado correctamente.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dato inválido");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Información");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}