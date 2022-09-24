using System;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia;

//colecciones de datos, manejdar de manera flexible las consultas en BD
using System.Collections.Generic;
//LINQ 
using System.Linq;

namespace PracticaVeterinaria.App.Persistencia.AppRepositorios
{

    public interface IRepositorioMascota
    {

       //firma de métodos del CRUD

        Mascota AddMascota(Mascota mascota);
        void DeleteMascota(int idMascota);

        Mascota GetMascota(int idMascota);

        Mascota UpdateMascota(Mascota mascota);

        IEnumerable<Mascota> GetAllMascotas();


    }

}






