using System;
using System.Collections.Generic;
using System.Linq;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia;

namespace PracticaVeterinaria.App.Persistencia.AppRepositorios
{
    public interface IRepositorioHistoriasClinicas
    {
        // Implementar la firma de los métodos del CRUD
        HistoriaClinica AddHistoriaClinica(HistoriaClinica historiasClinicas);
        HistoriaClinica UpdateHistoriaClinica(HistoriaClinica historiasClinicas);

        void DeleteHistoriaClinica(int id);

        // IEnumerable - me permite retornar una lista de objetos

        IEnumerable<HistoriaClinica> GetAllHistoriaClinica();

        HistoriaClinica GetHistoriaClinica(int id);
    }
}