//Directivas
using System;
using System.Collections.Generic;
using System.Linq;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia;

namespace PracticaVeterinaria.App.Persistencia.AppRepositorios
{
    public interface IRepositorioVeterinario
    {
        // Implementar la firma de los métodos del CRUD
        Veterinario AddVeterinario(Veterinario veterinarios);
        Veterinario UpdateVeterinario(Veterinario veterinarios);

        void DeleteVeterinario(int idVeterinario);

        // IEnumerable - me permite retornar una lista de objetos

        IEnumerable<Veterinario> GetAllVeterinario();

        Veterinario GetVeterinario(int idVeterinario);
    }
}