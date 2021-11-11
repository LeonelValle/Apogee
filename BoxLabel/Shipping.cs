using System;

namespace BoxLabel
{
    class Shipping : Conexion
    {
        int id_ship;
        int id_inp;
        DateTime dateship;

        public int Id_ship { get => id_ship; set => id_ship = value; }
        public int Id_inp { get => id_inp; set => id_inp = value; }
        public DateTime Dateship { get => dateship; set => dateship = value; }
    }
}
