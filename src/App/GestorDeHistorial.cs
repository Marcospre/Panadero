using System;
using Data;
using Modelos;
using System.Collections.Generic;


namespace App
{

    public class GestorDeHistorial
    {
        IData<Compra> RepoHistorial;
        public List<Compra> Historial_Compras;
        public GestorDeHistorial(IData<Compra> repo){
            RepoHistorial = repo;
            Historial_Compras = RepoHistorial.Leer();
        }

        public void NuevaCompra(Compra nueva)
        {   
            Historial_Compras.Add(nueva);
            RepoHistorial.Guardar(Historial_Compras);
        }

        public int ContarCompras()
        {
            string id = Historial_Compras[0].idCompra;
            int cont = 1;

            foreach(Compra obj in Historial_Compras)
            {
                if(obj.idCompra != id){
                    cont++;
                    id = obj.idCompra;
                }
            }

            return cont;
        }
    }
}
