using System;
using System.Collections.Generic;


namespace Modelos
{

   public class Compra
    {
        public string idCliente{get;set;}
        public string lista;
        public List<Pan> compra;
        public double precio{get;set;}
        public DateTime fecha_compra;
        public bool pagado{get;set;}

        public Compra(String id, List<Pan> compra, bool pagado){
            this.idCliente = id;
            this.compra = compra;
            this.pagado = pagado;
            this.fecha_compra = DateTime.Now;
            this.compra = compra;
            listar();
            calculoPrecio();
        }

        public Compra(String id, DateTime fecha, Double precio, bool pagado, string lista){
            this.idCliente = id;
            this.fecha_compra = fecha;
            this.precio = precio;
            this.pagado = pagado;
            this.lista = lista;
        }
        


        public void listar(){
            foreach(Pan obj in compra){
                lista = lista + $"{obj.tipo}:{obj.cantidad}";
            }
        }

        public void calculoPrecio(){
        foreach(Pan obj in compra){
                precio = precio + obj.precio*obj.cantidad;
            } 
        }


    }
}