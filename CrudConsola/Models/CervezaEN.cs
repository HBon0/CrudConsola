using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsola.Models
{
    public class CervezaEN 
    {
        public int Id { get; set; }
        public string nombre { get; set; }

        public int cantidad { get; set; }

        public int alcohol { get; set; }

        public string marca { get; set; }

        public CervezaEN()
        {

        }
    }
}
