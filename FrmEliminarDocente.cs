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
    public partial class FrmEliminarDocente : Form
    {
        public FrmEliminarDocente()
        {
            InitializeComponent();
            CargarTabla();
        }

        // Crea las columnas y llena la tabla
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

        // Llena la tabla con lo que hay en el arreglo
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Almacen.TotalDocentes == 0)
                    throw new InvalidOperationException("No hay docentes para eliminar.");

                if (dgvDocentes.CurrentRow == null)
                    throw new ArgumentException("Seleccione un docente de la tabla.");

                int posicion = dgvDocentes.CurrentRow.Index;
                Docente d = Almacen.Docentes[posicion];

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea eliminar a " + d.Nombres + " " + d.Apellidos + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    Almacen.EliminarDocente(posicion);
                    MostrarDocentes();
                    MessageBox.Show("Docente eliminado correctamente.");
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