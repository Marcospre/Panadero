using System;
using System.Collections.Generic;


namespace Modelos
{

   public class Compra
    {
        public string idCompra{get;set;}
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
            this.idCompra = generarCodigo();
            listar();
            calculoPrecio();
        }

        public Compra(String id_compra, String id, DateTime fecha, Double precio, bool pagado, string lista){
            this.idCompra = id_compra;
            this.idCliente = id;
            this.fecha_compra = fecha;
            this.precio = precio;
            this.pagado = pagado;
            this.lista = lista;
        }
        



        public string generarCodigo(){
            return $"{idCliente}{fecha_compra.Day}";
        }
        public void listar(){
            foreach(Pan obj in compra){
                lista = lista + $"{obj.tipo}:{obj.cantidad} ";
            }
        }

        public void calculoPrecio(){
        foreach(Pan obj in compra){
                precio = precio + obj.precio*obj.cantidad;
            } 
        }

        public string listarcompra(){
            string m="";

            foreach(Pan obj in compra){
                m = m +obj.cantidad + obj.tipo;
            }

            return m;
        }

        public string topendiente(){
            return $"El precio de {listarcompra()} es de {precio}";
        }

        public override string ToString()
        {
            return $"idCompra:{idCompra} idCliente:{idCliente}";
        }


    }
}