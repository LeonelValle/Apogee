using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxLabel
{
    class Box : Conexion
    {
        int id_box;
        string box;
        int consecutive;
        string nom;

        public int Id_box { get => id_box; set => id_box = value; }
        public string Boxes { get => box; set => box = value; }
        public int Consecutive { get => consecutive; set => consecutive = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
