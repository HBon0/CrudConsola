using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* -------------------------------------------------------- */
using AccesoADatos.Servicios;
using EntidadesDeNegocios.Models;

namespace CrudCatalogoEmpresas
{
    public partial class FrmEliminar : Form
    {
        public static int id;
        

        public FrmEliminar()
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    CatalogoEmpresaDAL catEmpresaDAL = new CatalogoEmpresaDAL();
                    catEmpresaDAL.Delete(id);

                    MessageBox.Show("Registro eliminado correctamente");
                } 
            } catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            btnEliminar.Enabled = false;
        }
    }
}
