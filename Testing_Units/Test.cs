using System;

namespace Testing_Units
{
    class Test : Conexion
    {
        int id;
        string test;
        DateTime date_test;

        public int Id { get => id; set => id = value; }
        public string Tested { get => test; set => test = value; }
        public DateTime Date_test { get => date_test; set => date_test = value; }
    }
}
