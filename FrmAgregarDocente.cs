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
    public partial class FrmAgregarDocente : Form
    {
        public FrmAgregarDocente()
        {
            InitializeComponent();
        }

        private void FrmAgregarDocente_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSexo.SelectedItem == null)
                    throw new ArgumentException("Seleccione el sexo.");

                Docente d = new Docente(txtNombres.Text, txtApellidos.Text,
                                        dtpFecha.Value, cmbSexo.SelectedItem.ToString(),
                                        txtProfesion.Text, txtAsignatura.Text);
                Almacen.AgregarDocente(d);
                MessageBox.Show("Docente agregado correctamente.");
                LimpiarCampos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtProfesion.Clear();
            txtAsignatura.Clear();
            cmbSexo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;
            txtNombres.Focus();
        }
    }
}