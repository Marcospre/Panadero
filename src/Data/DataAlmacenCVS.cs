using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using Modelos;

namespace Data;

class DataAlmacenCSV:IData<Pan>
{
   string _file = "../../Almacen.csv";

   public void Guardar(List<Pan> panes){
       List<string> data = new(){ };
       panes.ForEach (Pan =>
        {
           var str = $"{Pan.tipo},{Pan.precio},{Pan.cantidad}";
           data.Add(str);
        });
       {
           
       }
   } 

   public List<Pan> Leer()
        {
            List<Pan> panes = new();
            var data = File.ReadAllLines(_file).ToList();
            data.ForEach(row =>
            {
                var campos = row.Split(",");
                var pan = new Pan
                {   
                    tipo = campos[0],
                    precio = double.Parse(campos[1]),
                    cantidad = Int32.Parse(campos[2])
                };
                panes.Add(pan);
            });
            return panes;
        }
}