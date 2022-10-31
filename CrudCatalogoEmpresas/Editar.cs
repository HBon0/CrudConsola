using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* ---------------------------------------------------- */
using AccesoADatos.Servicios;
using EntidadesDeNegocios.Models;

namespace CrudCatalogoEmpresas
{
    public partial class FrmEditar : Form
    {
        public static int id;

        public FrmEditar()
        {
            InitializeComponent();
            id = FrmHome.id;
            CatalogoEmpresa catEmpresa = new CatalogoEmpresa();
            CatalogoEmpresaDAL catEmpresaDAL = new CatalogoEmpresaDAL();

            catEmpresa = catEmpresaDAL.GetId(id);

            txtCodigo.Text = catEmpresa.Codigo;
            txtNombre.Text = catEmpresa.Nombre;
            txtTelefono.Text = Convert.ToString(catEmpresa.Telefono);
            txtDireccion.Text = catEmpresa.Direccion;
            txtCorreo.Text = catEmpresa.Correo;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogoEmpresa catEmpresa = new CatalogoEmpresa();
                catEmpresa.Codigo = txtCodigo.Text;
                catEmpresa.Nombre = txtNombre.Text;
                catEmpresa.Telefono = Convert.ToInt32(txtTelefono.Text);
                catEmpresa.Direccion = txtDireccion.Text;
                catEmpresa.Correo = txtCorreo.Text;

                CatalogoEmpresaDAL catEmpresaDAL = new CatalogoEmpresaDAL();
                catEmpresaDAL.Update(catEmpresa, id);

                MessageBox.Show("Registro actualizado correctamente");
            } catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal");
            }

            btnEditar.Enabled = false;
        }
    }
}
