using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ----------------------------------- */
using System.Data.SqlClient;
using Dapper;
using EntidadesNegocio;

namespace AccesoADatosWinForm
{
    public class RolDAL
    {
        private string ConnectionString = "workstation id=PruebaPersonal.mssql.somee.com;packet size=4096;" +
            "user id=BoniDev_SQLLogin_1;pwd=pfkfdconl7;data source=PruebaPersonal.mssql.somee.com;" +
            "persist security info=False;initial catalog=PruebaPersonal";
        public List<RolEN> GetTodos()
        {
            List<RolEN> listRol = new List<RolEN>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "select * from Rol";
                var roles = connection.Query<RolEN>(sql);
                foreach (var item in roles)
                {
                    listRol.Add(item);
                }
            }

            return listRol;
        }

        public RolEN GetId(int id)
        {
            RolEN rol = new RolEN();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = $"select * from Rol where id={id}";
                rol = connection.QuerySingle<RolEN>(sql);
            }

            return rol;
        }

        public void Add(RolEN pRol)
        {
            var sql = $"insert into Rol (nombre, estado) values ('{pRol.Nombre}',{pRol.Estado})";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var affectedRows = connection.Execute(sql);
                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
        }

        public void Update(RolEN pRol, int id)
        {
            var sql = $"update Rol set nombre='{pRol.Nombre}',estado={pRol.Estado} where id={id}";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var affectedRows = connection.Execute(sql);
                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
        }

        public void Delete(int id)
        {
            var sql = $"delete from Rol where id={id}";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var affectedRows = connection.Execute(sql);
                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
        }
    }
}
