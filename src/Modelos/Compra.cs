using System;


namespace Compra;

class Compra
{
    string idCliente{get;set;}
    string lista;
    List<Pan> compra;
    double precio{get;set;}
    DateTime fecha_compra;

    public Compra(String id, List<Pan> compra){
        this.idCliente = id;
        this.compra = compra;
        this.fecha_compra = DateTime.Now;
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