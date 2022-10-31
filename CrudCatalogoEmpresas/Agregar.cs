using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* ------------------------------------------------------------- */
using AccesoADatos.Servicios;
using EntidadesDeNegocios.Models;

namespace CrudCatalogoEmpresas
{
    public partial class FrmAgregar : Form
    {
        public FrmAgregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try {
                CatalogoEmpresa catEmpresa = new CatalogoEmpresa();
                catEmpresa.Codigo = txtCodigo.Text;
                catEmpresa.Nombre = txtNombre.Text;
                catEmpresa.Telefono = Convert.ToInt32(txtTelefono.Text);
                catEmpresa.Direccion = txtDireccion.Text;
                catEmpresa.Correo = txtCorreo.Text;

                CatalogoEmpresaDAL catEmpresaDAL = new CatalogoEmpresaDAL();
                catEmpresaDAL.Add(catEmpresa);

                MessageBox.Show("Registro creado Correctamente");
                btnAgregar.Enabled = false;

            } catch (Exception ex)
            {
                MessageBox.Show("Algo salio Mal");
            }

            
        }
    }
}
