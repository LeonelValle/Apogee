using System;
using System.Collections.Generic;

namespace BoxLabel
{
    class Inprocess : Conexion
    {
        int id_inprocess;
        string serialNumber;
        DateTime regSN;

        List<string> listSN = new List<string>();

        public int Id_inprocess { get => id_inprocess; set => id_inprocess = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public DateTime RegSN { get => regSN; set => regSN = value; }
        public List<string> ListSN { get => listSN; set => listSN = value; }
    }
}
