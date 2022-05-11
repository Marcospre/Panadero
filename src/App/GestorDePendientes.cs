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
    }
}