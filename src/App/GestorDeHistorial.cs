using System;
using Data;
using Modelos;
using System.Collections.Generic;

namespace App;

class GestorDeHistorial
{
    IData<Compra> RepoHistorial;
    public List<Compra> Historial_Compras;
    public GestorDeMascota(IData<Compra> repo){
        RepoHistorial = repo;
        Historial_Compras = RepoHistorial.Leer();
    }
}
