using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* --------------------------- */
using AccesoADatosWinForm;
using EntidadesNegocio;

namespace UI
{
    public partial class FrmAgregarRol : Form
    {
        public FrmAgregarRol()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            FrmAgregarRol frmAgregarRol = new FrmAgregarRol();

            RolEN pRol = new RolEN();
            RolDAL rolDAL = new RolDAL();

            try
            {
                pRol.Nombre = txtName.Text;
                pRol.Estado = Convert.ToByte(txtEstatus.Text);

                rolDAL.Add(pRol);
                MessageBox.Show("Registro Creado");
                frmAgregarRol.Close();
            } 
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al crear el registro");
                frmAgregarRol.Close();
            }


            
            
        }
    }
}
