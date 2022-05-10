using System;
using Modelos;
using Data;

namespace App;

class GestorDePendientes
{
    IData<Compra> RepoPendientes;
    public List<Compra> Pendientes;
    public GestorDeMascota(IData<Compra> repo){
        RepoPendientes = repo;
        Pendientes = RepoPendientes.Leer();
    } 
}