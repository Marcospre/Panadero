using System;
using Data;
using Modelos;

namespace App;

class GestorDeAlmacen
{
    IData<Pan> RepoAlmacen;
    public List<Pan> Panes;

    public GestorDeAlmacen(IData<Pan> repo){
        RepoAlmacen = repo;
        Panes = RepoAlmacen.Leer();
    }

    public void sumarPanes();
    public void restarPanes();
}