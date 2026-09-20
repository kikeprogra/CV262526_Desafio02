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
    public partial class FrmModificarAlumno : Form
    {
        public FrmModificarAlumno()
        {
            InitializeComponent();

            btnGuardar.Click += btnGuardar_Click;
            btnCerrar.Click += btnCerrar_Click;
            dgvAlumnos.CellClick += dgvAlumnos_CellClick;

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

        private void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCarrera.Clear();
            txtCarnet.Clear();
            cmbSexo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;
            dgvAlumnos.ClearSelection();
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= Almacen.TotalAlumnos)
                    return;

                Alumno a = Almacen.Alumnos[e.RowIndex];
                txtNombres.Text = a.Nombres;
                txtApellidos.Text = a.Apellidos;
                dtpFecha.Value = a.FechaNacimiento;
                cmbSexo.SelectedItem = a.Sexo;
                txtCarrera.Text = a.Carrera;
                txtCarnet.Text = a.Carnet;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Almacen.TotalAlumnos == 0)
                    throw new InvalidOperationException("No hay alumnos para modificar.");

                if (dgvAlumnos.CurrentRow == null || dgvAlumnos.SelectedRows.Count == 0)
                    throw new ArgumentException("Seleccione un alumno de la tabla.");

                if (cmbSexo.SelectedItem == null)
                    throw new ArgumentException("Seleccione el sexo.");

                int posicion = dgvAlumnos.CurrentRow.Index;

                Alumno nuevo = new Alumno(txtNombres.Text, txtApellidos.Text,
                                          dtpFecha.Value, cmbSexo.SelectedItem.ToString(),
                                          txtCarrera.Text, txtCarnet.Text);

                if (Almacen.CarnetExiste(nuevo.Carnet, posicion))
                    throw new InvalidOperationException("Ya existe otro alumno con ese carnet.");

                Almacen.Alumnos[posicion] = nuevo;
                MostrarAlumnos();
                LimpiarCampos();
                MessageBox.Show("Alumno modificado correctamente.");
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