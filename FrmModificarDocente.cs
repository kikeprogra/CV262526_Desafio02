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
    public partial class FrmModificarDocente : Form
    {
        public FrmModificarDocente()
        {
            InitializeComponent();

            btnGuardar.Click += btnGuardar_Click;
            btnCerrar.Click += btnCerrar_Click;
            dgvDocentes.CellClick += dgvDocentes_CellClick;

            CargarTabla();
        }

        private void CargarTabla()
        {
            try
            {
                dgvDocentes.Columns.Clear();
                dgvDocentes.Columns.Add("colNombres", "Nombres");
                dgvDocentes.Columns.Add("colApellidos", "Apellidos");
                dgvDocentes.Columns.Add("colFecha", "Fecha de nacimiento");
                dgvDocentes.Columns.Add("colSexo", "Sexo");
                dgvDocentes.Columns.Add("colProfesion", "Profesión");
                dgvDocentes.Columns.Add("colAsignatura", "Asignatura");

                MostrarDocentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los docentes: " + ex.Message);
            }
        }

        private void MostrarDocentes()
        {
            dgvDocentes.Rows.Clear();
            for (int i = 0; i < Almacen.TotalDocentes; i++)
            {
                Docente d = Almacen.Docentes[i];
                dgvDocentes.Rows.Add(d.Nombres, d.Apellidos,
                                     d.FechaNacimiento.ToShortDateString(),
                                     d.Sexo, d.Profesion, d.Asignatura);
            }
        }

        private void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            TxtProfesion.Clear();
            txtAsignatura.Clear();
            cmbSexo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;
            dgvDocentes.ClearSelection();
        }

        private void dgvDocentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= Almacen.TotalDocentes)
                    return;

                Docente d = Almacen.Docentes[e.RowIndex];
                txtNombres.Text = d.Nombres;
                txtApellidos.Text = d.Apellidos;
                dtpFecha.Value = d.FechaNacimiento;
                cmbSexo.SelectedItem = d.Sexo;
                label7.Text = d.Profesion;
                txtAsignatura.Text = d.Asignatura;
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
                if (Almacen.TotalDocentes == 0)
                    throw new InvalidOperationException("No hay docentes para modificar.");

                if (dgvDocentes.CurrentRow == null || dgvDocentes.SelectedRows.Count == 0)
                    throw new ArgumentException("Seleccione un docente de la tabla.");

                if (cmbSexo.SelectedItem == null)
                    throw new ArgumentException("Seleccione el sexo.");

                int posicion = dgvDocentes.CurrentRow.Index;

                Docente nuevo = new Docente(txtNombres.Text, txtApellidos.Text,
                                            dtpFecha.Value, cmbSexo.SelectedItem.ToString(),
                                            label7.Text, txtAsignatura.Text);

                Almacen.Docentes[posicion] = nuevo;
                MostrarDocentes();
                LimpiarCampos();
                MessageBox.Show("Docente modificado correctamente.");
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