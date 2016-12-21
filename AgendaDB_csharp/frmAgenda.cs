using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaDB_csharp
{
    public partial class frmAgenda : Form
    {
        Operaciones o = new Operaciones();

        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            rbRegistrar.Checked = true;
            o.cargarContactos(dgvContactos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(o.insertar(txtNombre.Text, txtApellido.Text, txtApodo.Text, txtTelFijo.Text, txtTelMovil.Text, txtEmail.Text, txtFoto.Text, txtObservacion.Text));
            o.cargarContactos(dgvContactos);

            txtNombre.Clear();
            txtApellido.Clear();
            txtApodo.Clear();
            txtTelFijo.Clear();
            txtTelMovil.Clear();
            txtEmail.Clear();
            txtFoto.Clear();
            txtObservacion.Clear();
        }
    }
}
