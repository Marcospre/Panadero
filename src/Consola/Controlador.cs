using System;
using Modelos;
using System.Collections.Generic;
using System.Linq;


namespace Consola
{
    class Controlador
    {
        private Vista _vista;
        private Dictionary<String, Action> _casosDeUso;
        public Controlador(Vista vista)
        {
            this._vista = vista;
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
    }
}