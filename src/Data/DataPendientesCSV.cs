using System;


namespace Data;

class DataPendientesCSV:IData
{
    string _file = "../../Pendientes.csv";

    public void Guardar(List<Compra> pend)
    {
        List<string> data = new(){ };
           compra.ForEach(Compra =>
           {
               var str = $"{Compra.idCliente},{Compra.fecha_compra},{Compra.pagado},{Compra.lista}";
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
                    pagado = campos[2],
                    lista = campos[3]
                    
                };
                compras.Add(compra);
            });
            return compras;
       }
}