using System;

using System.Collections.Generic;

using System.IO;
using System.Linq;
using Modelos;

namespace Data;

class DataHistorialCSV:IData<Compra>
{
    string _file = "../../Historial.csv";

       public void Guardar(List<Compra> compra){
           List<string> data = new(){ };
           compra.ForEach(Compra =>
           {
               var str = $"{Compra.idCliente},{Compra.fecha_compra},{Compra.lista}";
               data.Add(str);
           });
           File.WriteAllLines(_file, data);
        
       }
       
       public List<Compra> Leer()
       {
           List<Compra> compras = new();
           var data = File.ReadAllLines(_file).ToList();
            data.ForEach(row =>
            {
                var campos = row.Split(",");
                var compra = new Compra
                {
                    idCliente = campos[0],
                    fecha_compra = campos[1],
                    lista = campos[2]
                    
                };
                compras.Add(compra);
            });
            return compras;
       }

}