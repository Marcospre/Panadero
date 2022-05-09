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
       List<string> data = new(){};
       panes.foreach (Pan =>
        {
           var str = $"{Pan.tipo},{Pan.precio},{Pan.cantidad}";
           data.Add(str);
        });
       {
           
       }
   } 
}