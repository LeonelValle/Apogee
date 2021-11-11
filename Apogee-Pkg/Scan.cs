using System;

namespace SupplyPro_Project
{
    class Scan : Conexion
    {
        public int id_scan { get; set; }
        //public int id_inprocess { get; set; }
        public string sn { get; set; }
        public DateTime dateReg { get; set; }
        public int id_wo { get; set; }
        public int id_box { get; set; }
        public int box { get; set; }
        public int id_inprocess { get; set; }

    }
}
