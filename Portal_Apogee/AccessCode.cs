using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal_Apogee
{
    public class AccessCode : Conexion
    {
        int id;
        string ac;

        public int Id { get => id; set => id = value; }
        public string Ac { get => ac; set => ac = value; }
    }
}