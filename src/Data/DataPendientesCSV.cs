using System;
using System.IO;
using System.Linq;
using Modelos;
using System.Collections.Generic;

namespace Data
{

    public class DataPendientesCSV:IData<Compra>
    {
        string _file = "../../Pendientes.csv";

        public void Guardar(List<Compra> pend)
        {
            List<string> data = new(){ };
            pend.ForEach(Compra =>
            {
                var str = $"{Compra.idCliente},{Compra.fecha_compra},{Compra.precio},{Compra.pagado},{Compra.lista}";
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
                    var compra = new Compra(
                        id: campos[0],
                        fecha: DateTime.Parse(campos[1]),
                        precio: Double.Parse(campos[2]),
                        pagado: bool.Parse(campos[3]),
                        lista: campos[4]
                        
                    );
                    compras.Add(compra);
                });
                return compras;
        }
    }
}