using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRestaurante
{
    class listTIcket
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private double costo;
        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        private double total;
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public listTIcket(int _cantidad, string _nombre, double _costo, double _total)
        {
            this.Cantidad   = _cantidad;
            this.Nombre     = _nombre;
            this.Costo      = _costo;
            this.Total      = _total;
        }
    }
}
