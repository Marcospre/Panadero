using System;
using Data;
using Modelos;
using System.Collections.Generic;

namespace App;

class GestorDeCliente
{
    IData<Cliente> RepoCliente;
    public List<Cliente> Clientes;
    public GestorDeCliente(IData<Cliente> repo){
        RepoCliente = repo;
        Clientes = RepoCliente.Leer();
    }

    public void NuevoCliente(Cliente nuevo){
            Clientes.Add(nuevo);
            RepoCliente.Guardar(Clientes);
        }
        public void EliminarCliente(Cliente elimi){
            Clientes.Remove(elimi);
            RepoCliente.Guardar(Clientes);
        }
}