using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* --------------------------------------------------- */
using AccesoADatosWinForm;
using EntidadesNegocio;

namespace UI
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            RolDAL rolDAL = new RolDAL();
            dgvRoles.DataSource = rolDAL.GetTodos();

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarRol frmAgregarRol = new FrmAgregarRol();
            frmAgregarRol.Show();

            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditarRol frmEditarRol = new FrmEditarRol();
            frmEditarRol.Show();
            
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmEliminarRol frmEliminarRol = new FrmEliminarRol();
            frmEliminarRol.Show();
        }

        private void dgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRoles.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(this.dgvRoles.SelectedRows[0].Cells[0].Value);
                }
            } catch (Exception)
            {

            }
        }

        private void dgvRoles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
    }
}
