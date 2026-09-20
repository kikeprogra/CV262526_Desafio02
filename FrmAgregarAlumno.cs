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
    public partial class FrmAgregarAlumno : Form
    {
        public FrmAgregarAlumno()
        {
            InitializeComponent();

            // Conectamos el boton desde el codigo
            btnGuardar.Click += btnGuardar_Click;
        }

        private void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCarrera.Clear();
            txtCarnet.Clear();
            cmbSexo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;
            txtNombres.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSexo.SelectedItem == null)
                    throw new ArgumentException("No ha seleccionado el sexo.");

                Alumno a = new Alumno(txtNombres.Text, txtApellidos.Text,
                                      dtpFecha.Value, cmbSexo.SelectedItem.ToString(),
                                      txtCarrera.Text, txtCarnet.Text);

                if (Almacen.CarnetExiste(a.Carnet, -1))
                    throw new InvalidOperationException("Ya existe un alumno con ese carnet.");

                Almacen.AgregarAlumno(a);
                MessageBox.Show("Alumno agregado correctamente.");
                LimpiarCampos();
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

        private void FrmAgregarAlumno_Load(object sender, EventArgs e)
        {

        }
    }
}