using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ------------------------------------ */
using System.Data.SqlClient;
using Dapper;
using EntidadesDeNegocios.Models;

namespace AccesoADatos.Servicios
{
    public class CatalogoEmpresaDAL
    {
        private string ConnectionString = "Data Source=localhost;Initial Catalog=Pruebasv1;Integrated Security=True"; //String de Conexcion de BD

        public List<CatalogoEmpresa> GetTodos() //Metodo para obtener todas los Catalogos de Empresas
        {
            List<CatalogoEmpresa> ListCatEmpresas = new List<CatalogoEmpresa>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "exec [SelectAllEmpresas]";
                var catEmpresas = connection.Query<CatalogoEmpresa>(sql);
                foreach (var item in catEmpresas)
                {
                    ListCatEmpresas.Add(item);
                }
            }

            return ListCatEmpresas;
        }

        public CatalogoEmpresa GetId(int id) //Metodo para obtener un catalogo de Empresas por su ID. 
        {
            CatalogoEmpresa catEmpresa = new CatalogoEmpresa();
            var sql = "EXEC [SelectEmpresaID] @Id";
            var values = new { Id = id};

            using (var connection = new SqlConnection(ConnectionString))
            {
                catEmpresa = connection.QuerySingle<CatalogoEmpresa>(sql, values);
            }

            return catEmpresa;
        }

        public void Add(CatalogoEmpresa pCatalogoEmpresa) //Metodo para agregar una Empresa al catalogo. 
        {
            var sql = "EXEC [CreateEmpresa] @Codigo, @Nombre, @Telefono, @Direccion, @Correo";
            var values = new 
            { 
                Codigo = pCatalogoEmpresa.Codigo, 
                Nombre = pCatalogoEmpresa.Nombre , 
                Telefono = pCatalogoEmpresa.Telefono, 
                Direccion = pCatalogoEmpresa.Direccion, 
                Correo = pCatalogoEmpresa.Correo
            };

            using (var connection = new SqlConnection(ConnectionString))
            {
                var affectedRows = connection.Execute(sql, values);
            }
        }

        public void Update(CatalogoEmpresa pcatEmpresa, int id) //Metodo para actualizar una Empresa del catalogo 
        {
            var sql = "EXEC [UpdateEmpresa] @Id, @Codigo, @Nombre, @Telefono, @Direccion, @Correo";
            var values = new
            {
                Id = id,
                Codigo = pcatEmpresa.Codigo,
                Nombre = pcatEmpresa.Nombre,
                Telefono = pcatEmpresa.Telefono,
                Direccion = pcatEmpresa.Direccion,
                Correo = pcatEmpresa.Correo
            };
            
            using (var connection = new SqlConnection(ConnectionString))
            {
                var affectedRows = connection.Execute(sql, values);
            }
        }


        public void Delete(int id) //Metodo para borrar una empresa del catalogo. 
        {
            var sql = "EXEC [DeleteEmpresa] @Id";
            var values = new
            {
                Id = id
            };

            using (var connection = new SqlConnection(ConnectionString))
            {
                var affectedRows = connection.Execute(sql, values);
            }
        }
    }
}
