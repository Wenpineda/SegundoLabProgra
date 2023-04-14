using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioSupermercado
{
    public class Product
    {
        public string Name { get; set; }
        public string proveedor { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string detalles { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaCaducidad { get; set; }


    }
}
