using System;
using System.Collections.Generic;


namespace Modelos
{

   public class Compra
    {
        string idCliente{get;set;}
        string lista;
        List<Pan> compra;
        double precio{get;set;}
        DateTime fecha_compra;

        bool pagado{get;set;}

        public Compra(String id, List<Pan> compra, bool pagado){
            this.idCliente = id;
            this.compra = compra;
            this.pagado = pagado;
            this.fecha_compra = DateTime.Now;
            this.compra = compra;
            listar();
            calculoPrecio();
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