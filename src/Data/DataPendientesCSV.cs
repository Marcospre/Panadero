using System;
using System.IO;
using System.Linq;
using Modelos;
using System.Collections.Generic;
using System.Globalization;

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
                var str = $"{Compra.idCompra},{Compra.idCliente},{Compra.fecha_compra},{Compra.precio.ToString(CultureInfo.InvariantCulture)},{Compra.pagado},{Compra.lista}";
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
                        id_compra:campos[0],
                        id: campos[1],
                        fecha: DateTime.Parse(campos[2]),
                        precio: Decimal.Parse(campos[3],CultureInfo.InvariantCulture),
                        pagado: bool.Parse(campos[4]),
                        lista: campos[5]
                        
                    );
                    compras.Add(compra);
                });
                return compras;
        }
    }
}