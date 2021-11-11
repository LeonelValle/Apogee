using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyPro_Project
{
    class Test : Conexion
    {
		public string sn { get; set; }
		public string imei { get; set; }
		public string mac { get; set; }
		public string nuc_mac { get; set; }
		public string nuc_sn { get; set; }
		public string mediabox_sn { get; set; }
		public string result { get; set; }
		public DateTime test_time { get; set; }
	}
}
