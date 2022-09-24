using System;
using System.Collections.Generic;
using System.Linq;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia;

namespace PracticaVeterinaria.App.Persistencia
{
    public interface IRepositorioVisita
    {
        // Implementar la firma de los métodos del CRUD
        Visita AddVisita(Visita visitas);
        Visita UpdateVisita(Visita visitas);

        void DeleteVisita(int id);

        // IEnumerable - me permite retornar una lista de objetos

        IEnumerable<Visita> GetAllVisita();

        Visita GetVisita(int id);
    }
}