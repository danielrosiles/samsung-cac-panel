using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamsungTest1.Models
{
    public class ClienteClass
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public char sexo { get; set; }
        public string telefono { get; set; }
        public string plan { get; set; }
    }
}