using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* ---------------------------------------------------------- */
using AccesoADatos.Servicios;
using EntidadesDeNegocios.Models;

namespace CrudCatalogoEmpresas
{
    public partial class FrmHome : Form
    {
        public static int id;

        public FrmHome()
        {
            InitializeComponent();
            CatalogoEmpresaDAL catEmpresas = new CatalogoEmpresaDAL();
            dgvCatalogoEmpresas.DataSource = catEmpresas.GetTodos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregar frmAgregar = new FrmAgregar();
            frmAgregar.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CatalogoEmpresaDAL catEmpresaDAL = new CatalogoEmpresaDAL();
             dgvCatalogoEmpresas.DataSource = catEmpresaDAL.GetTodos();

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void dgvCatalogoEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCatalogoEmpresas.SelectedRows.Count > 0)
                {
                    id = Convert.ToInt32(this.dgvCatalogoEmpresas.SelectedRows[0].Cells[0].Value);
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }

            } catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido un error, trate de nuevo");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmEditar frmEditar = new FrmEditar();
            frmEditar.Show();

            btnModificar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmEliminar frmEliminar = new FrmEliminar();
            frmEliminar.Show();

            btnEliminar.Enabled = false;
        }

        private void btnBuscarID_Click(object sender, EventArgs e)
        {
            List<CatalogoEmpresa> listCatEmpresa = new List<CatalogoEmpresa>();
            var Id = Convert.ToInt32(txtId.Text);

            CatalogoEmpresaDAL catEmpresaDAL = new CatalogoEmpresaDAL();
            var catEmpresa = catEmpresaDAL.GetId(Id);
            listCatEmpresa.Add(catEmpresa);

            dgvCatalogoEmpresas.DataSource = listCatEmpresa;
        }
    }
}
