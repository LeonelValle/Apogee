using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyPro_Project
{
    class PN : Conexion
    {
        public int id_pn { get; set; }
        public string pn { get; set; }
        public string rev { get; set; }
        public string desc { get; set; }
        public int unit { get; set; }


    }
}
