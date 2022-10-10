using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* ------------------------------------- */
using CrudConsola.Models;
using Dapper;
using System.Data.SqlClient;

namespace CrudConsola.AccesoADatos
{
    public class RolDAL
    {
        private string ConnectionString = "workstation id=PruebaPersonal.mssql.somee.com;packet size=4096;" +
            "user id=BoniDev_SQLLogin_1;pwd=pfkfdconl7;data source=PruebaPersonal.mssql.somee.com;" +
            "persist security info=False;initial catalog=PruebaPersonal"; 
        public List<Rol> GetTodos ()
        {
            List<Rol> listRol = new List<Rol>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "select * from Rol";
                var roles = connection.Query<Rol>(sql);
                foreach (var item in roles)
                {
                    listRol.Add(item);
                }
            }

            return listRol;
        }

        public void Add (Rol pRol)
        {
            var sql = $"insert into Rol (nombre, estado) values ('{pRol.Nombre}',{pRol.Estado})";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var affectedRows = connection.Execute(sql);
                Console.WriteLine($"Affected Rows: {affectedRows}");
            }
        }

        public void Update(Rol pRol, int id)
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
