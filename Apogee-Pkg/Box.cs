using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyPro_Project
{
    class Box : Conexion
    {
        int id_box;
        string box;
        int countBox;
        int topBox;
        public int Id_box { get => id_box; set => id_box = value; }
        public string Boxs { get => box; set => box = value; }
        public int CountBox { get => countBox; set => countBox = value; }
        public int TopBox { get => topBox; set => topBox = value; }
    }
}
