using System;
using Modelos;
using App;
using System.Collections.Generic;
using System.Linq;


namespace Consola
{
    class Controlador
    {
        private Vista _vista;
        private Dictionary<String, Action> _casosDeUso;
        private GestorDeCliente sistema_clientes;
        private GestorDeHistorial sistema_historial;
        private GestorDePendientes sistema_pendientes;
        private GestorDeAlmacen sistema_almacen;
        public Controlador(Vista vista, GestorDeCliente gesClientes, GestorDeAlmacen sistema_almacen, GestorDeHistorial sistema_historial, GestorDePendientes sistema_pendientes)
        {
            this._vista = vista;
            this.sistema_pendientes = sistema_pendientes;
            this.sistema_historial = sistema_historial;
            this.sistema_almacen = sistema_almacen;
            this.sistema_clientes = gesClientes;
            _casosDeUso = new Dictionary<string,Action>()
            {
                {"Realizar compra", RealizarCompra},
                {"Pagar compras",PagarCompras},
                {"Historial de pendientes",HistorialPendientes},
                {"Historial compras",HistorialCompras},
                {"Salir",Salir}
            };
        }

        public void Run()
        {
            _vista.LimpiarPantalla();
            var menu = _casosDeUso.Keys.ToList<String>();

            while(true)
            try{
                _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Menu de Usuario", menu, "Selecciona una opcion");
                _vista.Mostrar("");
                _casosDeUso[key].Invoke();
                _vista.MostrarYReturn("Pulsa <Return> para continuar");
            }
            catch {return;}

            
        }

        private void RealizarCompra()
        {   
            Compra nueva_compra;
            List<Pan> lista_panes = new List<Pan>();
            bool salir = false;
            List<string> menu_cliente = new List<string>
            {
                "Nuevo Cliente",
                "Registrarse"
            };
           
            _vista.MostrarListaEnumerada("Cliente",menu_cliente);
            try
            {
                
                var input = _vista.TryObtenerValorEnRangoInt(1, menu_cliente.Count, "Seleccione una opcion");
                Cliente cliente;
                if(input == 1 )
                    cliente = NuevoCliente();
                else
                    cliente = _vista.TryObtenerElementoDeLista<Cliente>("Clientes",sistema_clientes.Clientes,"Seleccione un cliente");
                
                while(!salir){
                    
                    Pan pan = _vista.TryObtenerElementoDeLista<Pan>("Pan",sistema_almacen.Panes,"Seleccione una opcion");
                    var cantidad = _vista.TryObtenerDatoDeTipo<int>("Cantidad");
                    if(cantidad > pan.cantidad){
                        throw new Exception("La cantidad a comprar es mayor que la almacenada");
                    }

                    Pan nuevo_pan = new Pan(pan.tipo,pan.precio,cantidad);
                    sistema_almacen.RestarPan(nuevo_pan,nuevo_pan.cantidad);
                    lista_panes.Add(nuevo_pan);
                    
                    Console.Write("Desea comprar mas?(s/n):");
                    var res = Console.ReadLine();

                    if(res.Equals("n"))
                        salir = true;

                }



                Console.Write("Pagar ahora o mas tarde?(a/m):");
                var res1 = Console.ReadLine();
                if(res1.Equals("a")){
                    nueva_compra = new Compra(cliente.idCliente,lista_panes,true);
                    _vista.Mostrar("Pagado",ConsoleColor.Yellow);
                    sistema_historial.NuevaCompra(nueva_compra);
                }else{
                    nueva_compra = new Compra(cliente.idCliente,lista_panes,false);
                    _vista.Mostrar(" No Pagado",ConsoleColor.Yellow);
                    sistema_pendientes.NuevaCompra(nueva_compra);
                }
                
            }
            catch (System.Exception e)
            {
                
                Console.WriteLine(e.Message);
            }
        }

        private Cliente NuevoCliente()
        {
            try{
                var idCliente = _vista.TryObtenerDatoDeTipo<string>("idCliente");
                var nom = _vista.TryObtenerDatoDeTipo<string>("Nombre");
                var ape = _vista.TryObtenerDatoDeTipo<string>("Apellido");

                Cliente nuevoCliente = new Cliente
                (
                    idCliente:idCliente,
                    nombre: nom,
                    apellido:ape
                );

                sistema_clientes.NuevoCliente(nuevoCliente);
                return nuevoCliente;
            }catch(System.Exception)
            {
                throw;
            }
        }

        private void PagarCompras()
        {
            try{
                Compra nueva_compra = null;
                var cliente = _vista.TryObtenerElementoDeLista<Cliente>("Cliente",sistema_clientes.Clientes,"Selecciona cliente");
                if(sistema_pendientes.buscar_cliente(cliente)){
                    List<Compra> lista_pendientes = sistema_pendientes.obtener_pendientes(cliente);
                    var compra = _vista.TryObtenerElementoDeLista<Compra>("Pendientes",lista_pendientes,"Seleccione una opcion");
                    string m = compra.topendiente()+"\n"
                            +"Desea pagar?(s/n)";
                    _vista.Mostrar(m);
                    var input = Console.ReadLine();

                    if(input.Equals("s")){
                        nueva_compra = new Compra(compra.idCompra,compra.idCliente,DateTime.Now,compra.precio,true,compra.ListaCompra);
                        _vista.Mostrar("Pagado",ConsoleColor.Yellow);
                        sistema_historial.NuevaCompra(nueva_compra);
                        sistema_pendientes.BorrarRegistro(nueva_compra);
                    }else{
                        _vista.Mostrar("No Pagado",ConsoleColor.Yellow);
                    }
                }else{
                    _vista.Mostrar("No tiene pagos pendientes");
                }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }

        private void HistorialPendientes(){
            try{
                _vista.MostrarListaEnumerada<Compra>("Lista pendientes", sistema_pendientes.Pendientes);
                
            }catch(Exception e ){
                Console.WriteLine(e.Message);
            }
        }

       
        private void HistorialCompras()
        {
            //Compra compra = null;
           // Compra compra_ante = null;
            _vista.Mostrar("Historial Compras", ConsoleColor.Yellow);
            Console.WriteLine();

            for(int i = 0 ; i < sistema_historial.Historial_Compras.Count; i++)
            {

                _vista.MostrarListaEnumerada<Pan>($" Compra:{sistema_historial.Historial_Compras[i].idCompra}",sistema_historial.Historial_Compras[i].ListaCompra);
                /*compra = sistema_historial.Historial_Compras[i];
                if(compra.idCompra.Equals(compra_ante)){
                    _vista.Mostrar($"Compra:{sistema_historial.Historial_Compras[i].idCompra}", ConsoleColor.DarkBlue);
                }else{
                    _vista.MostrarListaEnumerada<Pan>()
                }

                compra_ante = compra;*/

            }

        }
        
        private void Salir()
        {

        }

        
    }
}