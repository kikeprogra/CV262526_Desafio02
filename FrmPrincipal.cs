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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            // Todos los botones se conectan aqui, desde el codigo
            btnAgregarDocente.Click += btnAgregarDocente_Click;
            btnVerDocentes.Click += btnVerDocentes_Click;
            btnModificarDocente.Click += btnModificarDocente_Click;
            btnEliminarDocente.Click += btnEliminarDocente_Click;

            btnAgregarAlumno.Click += btnAgregarAlumno_Click;
            btnVerAlumnos.Click += btnVerAlumnos_Click;
            btnModificarAlumno.Click += btnModificarAlumno_Click;
            btnEliminarAlumno.Click += btnEliminarAlumno_Click;

            btnSalir.Click += btnSalir_Click;
        }

        // ---------- DOCENTES ----------

        private void btnAgregarDocente_Click(object sender, EventArgs e)
        {
            FrmAgregarDocente frm = new FrmAgregarDocente();
            frm.ShowDialog();
        }

        private void btnVerDocentes_Click(object sender, EventArgs e)
        {
            FrmVerDocentes frm = new FrmVerDocentes();
            frm.ShowDialog();
        }

        private void btnModificarDocente_Click(object sender, EventArgs e)
        {
            FrmModificarDocente frm = new FrmModificarDocente();
            frm.ShowDialog();
        }

        private void btnEliminarDocente_Click(object sender, EventArgs e)
        {
            FrmEliminarDocente frm = new FrmEliminarDocente();
            frm.ShowDialog();
        }

        // ---------- ALUMNOS ----------

        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            FrmAgregarAlumno frm = new FrmAgregarAlumno();
            frm.ShowDialog();
        }

        private void btnVerAlumnos_Click(object sender, EventArgs e)
        {
            FrmVerAlumnos frm = new FrmVerAlumnos();
            frm.ShowDialog();
        }

        private void btnModificarAlumno_Click(object sender, EventArgs e)
        {
            FrmModificarAlumno frm = new FrmModificarAlumno();
            frm.ShowDialog();
        }

        private void btnEliminarAlumno_Click(object sender, EventArgs e)
        {
            FrmEliminarAlumno frm = new FrmEliminarAlumno();
            frm.ShowDialog();
        }

        // ---------- SALIR ----------

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminarDocente_Click_1(object sender, EventArgs e)
        {

        }
    }
}