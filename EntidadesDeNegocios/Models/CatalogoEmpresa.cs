using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDeNegocios.Models
{
    public class CatalogoEmpresa
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public int Telefono { get; set; }

        public string Direccion { get; set; }
        
        public string Correo { get; set; }
    }
}
