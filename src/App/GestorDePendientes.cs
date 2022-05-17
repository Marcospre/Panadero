using System;
using Modelos;
using Data;
using System.Collections.Generic;

namespace App
{

    public class GestorDePendientes
    {
        IData<Compra> RepoPendientes;
        public List<Compra> Pendientes;
        public GestorDePendientes(IData<Compra> repo){
            RepoPendientes = repo;
            Pendientes = RepoPendientes.Leer();
        } 


        public void NuevaCompra(Compra nueva)
        {
            Pendientes.Add(nueva);
            RepoPendientes.Guardar(Pendientes);
        }

        public void BorrarRegistro(Compra borrar)
        {
            Compra eliminar = null;

            foreach(Compra obj in Pendientes){
                if(obj.idCompra.Equals(borrar.idCompra)){
                    eliminar = obj;
                }
            }
            Pendientes.Remove(eliminar);
            RepoPendientes.Guardar(Pendientes);
        }

        public bool buscar_cliente(Cliente cliente){

            bool enc = false;

            foreach(Compra obj in Pendientes){
                if(obj.idCliente.Equals(cliente.idCliente)){
                    enc = true;
                }
            }
            return enc;
        }

        public List<Compra> obtener_pendientes(Cliente cliente){

            List<Compra> p = new List<Compra>();

            foreach(Compra obj in Pendientes){
                if(obj.idCliente.Equals(cliente.idCliente)){
                    p.Add(obj);
                }
            }
            return p;
        }
    }
}