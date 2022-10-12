using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* ------------------------------- */
using AccesoADatosWinForm;
using EntidadesNegocio;

namespace UI
{
    public partial class FrmEliminarRol : Form
    {
        public static int id;
        RolDAL rolDAL = new RolDAL();
        RolEN rol = new RolEN();
        
        public FrmEliminarRol()
        {
            InitializeComponent();

            FrmHome home = new FrmHome();
            id = FrmHome.id;
            var rol = rolDAL.GetId(id);

            txtId.Text = Convert.ToString(rol.Id);
            txtNombre.Text = rol.Nombre;
            txtEstado.Text = Convert.ToString(rol.Estado);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    rolDAL.Delete(id);
                    MessageBox.Show("Registro eliminado correctamente");
                }
            } catch(Exception)
            {
                MessageBox.Show("Algo ha salido mal.");
            }

            btnEliminar.Enabled = false;
        }
    }
}
