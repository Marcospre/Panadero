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
        public Controlador(Vista vista, GestorDeCliente gesClientes)
        {
            this._vista = vista;
            this.sistema_clientes = gesClientes;
            _casosDeUso = new Dictionary<string,Action>()
            {
                {"Realizar compra"}
                {"Pagar compras"}
                {"Historial de pendientes"}
                {"Historial compras"}
                {"Salir"}
            }
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
            List<string> menu_cliente = new List<string>
            {
                "Nuevo Cliente",
                "Registrarse"
            };
           
            _vista.MostrarListaEnumerada("Cliente",menu_cliente);
            try
            {
                
                var input = _vista.TryObtenerValorEnRangoInt(1, menu_cliente.Count, "Seleccione una opcion");

                if(input == 1 ){
                    NuevoCliente();
                }else{

                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private void NuevoCliente()
        {
            try{
                var idCliente = _vista.TryObtenerDatoDeTipo<string>("idCliente");
                var nom = _vista.TryObtenerDatoDeTipo<string>("Nombre");
                var ape = _vista.TryObtenerDatoDeTipo<string>("Apellido");

                Cliente nuevoCliente = new Cliente
                {
                    idCliente = idCliente,
                    nombre = nom,
                    apellido = ape
                };

            sistema_clientes.NuevoCliente(nuevoCliente);
            }catch(System.Exception)
            {
                throw;
            }
        }

        private Cliente BuscarCliente(String id_cliente)
        {
            
        }
}