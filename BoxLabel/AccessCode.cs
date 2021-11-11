using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxLabel
{
    class AccessCode : Conexion
    {
        int id;
        string ac;
        bool used;
        DateTime date_used;

        public int Id { get => id; set => id = value; }
        public string Ac { get => ac; set => ac = value; }
        public bool Used { get => used; set => used = value; }
        public DateTime Date_used { get => date_used; set => date_used = value; }
    }
}
