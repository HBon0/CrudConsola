using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* ----------------------------------------- */
using AccesoADatosWinForm;
using EntidadesNegocio;

namespace UI
{
    public partial class FrmEditarRol : Form
    {
        RolDAL rolDAL = new RolDAL();
        RolEN rolEN = new RolEN();

        public static int id;
        public FrmEditarRol()
        {
            InitializeComponent();
            FrmHome home = new FrmHome();

            id = FrmHome.id;
            var rol = rolDAL.GetId(id);

            txtNombre.Text = rol.Nombre;
            txtEstado.Text = Convert.ToString(rol.Estado);
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                RolEN rol = new RolEN();
                rol.Nombre = txtNombre.Text;
                rol.Estado = Convert.ToByte(txtEstado.Text);
                rolDAL.Update(rol, id);

                MessageBox.Show("Registro actualizado correctamente");
            } catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error. ");
            }
        }
    }
}
