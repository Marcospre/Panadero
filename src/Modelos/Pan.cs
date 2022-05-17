using System;
namespace Modelos
{

    public class Pan
    {
        public string tipo{get;set;}
        public decimal precio{get;set;}
        public int cantidad{get;set;}

        public Pan(string tipo, decimal precio, int cantidad)
        {
            this.tipo = tipo;
            this.precio = precio;
            this.cantidad = cantidad;
        }
        
        public override string ToString()
        {
        return $"{tipo} precio:{precio} cantidad:{cantidad}";
        }
    }

    
}