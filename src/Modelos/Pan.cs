using System;
namespace Modelos
{

    public enum Tipo
    {
        Baguette,
        Integral,
        Gallego,
        Centeno
    }
    public class Pan
    {
        //public string tipo{get;set;}
        public Tipo tipo{get;set;}
        public Decimal precio{get;set;}
        public int cantidad{get;set;}

        public Pan(Tipo tipo, Decimal precio, int cantidad)
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