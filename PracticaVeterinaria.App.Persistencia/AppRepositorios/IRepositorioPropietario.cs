//Directivas
using System;
using System.Collections.Generic;
using System.Linq;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia;

namespace PracticaVeterinaria.App.Persistencia.AppRepositorios
{
    public interface IRepositorioPropietario
    {
        // Implementar la firma de los métodos del CRUD
        Propietario AddPropietario(Propietario propietario);
        Propietario UpdatePropietario(Propietario propietario);

        void DeletePropietario(int idPropietario);

        // IEnumerable - me permite retornar una lista de objetos

        IEnumerable<Propietario> GetAllPropietarios();

        Propietario GetPropietario(int idPropietario);
    }
}