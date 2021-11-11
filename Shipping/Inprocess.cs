using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping
{
    class Inprocess : Conexion
    {
        int id_inprocess;
        string serialNumber;
        DateTime regSN;
        string rev;
        string modelo;
        string wo;
        int qty;
        string desc;

        public Inprocess()
        {

        }
        public Inprocess(int id, string Sn, string WO, int Quantity, string Descripcion, string Model, string Rev,  DateTime DateScan)
        {
            id_inprocess = id;
            serialNumber = Sn;
            Wo = WO;
            Qty = Quantity;
            Desc = Descripcion;
            modelo = Model;
            rev = Rev;
            regSN = DateScan;
        }
        public int Id_inprocess { get => id_inprocess; set => id_inprocess = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Wo { get => wo; set => wo = value; }
        public int Qty { get => qty; set => qty = value; }
        public string Desc { get => desc; set => desc = value; }
        public string PartNo { get => modelo; set => modelo = value; }
        public string Revision { get => rev; set => rev = value; }
        public DateTime ShippingDate { get => regSN; set => regSN = value; }
    }
}
