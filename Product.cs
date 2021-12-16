using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos
{
    public class Product
    {
        public enum Type
        {
            MONITOR,
            TECLADO,
            RATON,
            PLACA_BASE
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }

        public Type TypeProduct { get; set; }




    }
}
