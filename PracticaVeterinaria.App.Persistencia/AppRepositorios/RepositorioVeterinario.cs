using System;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia;

//colecciones de datos, manejdar de manera flexible las consultas en BD
using System.Collections.Generic;
//LINQ 
using System.Linq;

namespace PracticaVeterinaria.App.Persistencia.AppRepositorios
{

    public class RepositorioVeterinario:IRepositorioVeterinario
    {
        private readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinarios)
        {
            var veterinariosAdicionado = _appContext.veterinarios.Add(veterinarios);
            _appContext.SaveChanges();
            return veterinariosAdicionado.Entity;

        }
        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {
            var veterinariosActualizar = _appContext.veterinarios.SingleOrDefault(r => r.id == veterinario.id); //Id_Vet?
            if (veterinariosActualizar != null)
            {
                veterinariosActualizar.id = veterinario.id;  // nombres iguales a las entidades?
                veterinariosActualizar.nombres = veterinario.nombres;
                veterinariosActualizar.apellidos = veterinario.apellidos;
                veterinariosActualizar.telefono = veterinario.telefono;
                veterinariosActualizar.tarjetaProfesional = veterinario.tarjetaProfesional;
                _appContext.SaveChanges();
            }
            return veterinariosActualizar;
        }

        void IRepositorioVeterinario.DeleteVeterinario(int id) //(int idPropietario) ---  //Id_Vet?
        {
            var veterinariosEncontrado = _appContext.veterinarios.FirstOrDefault(c => c.id == id); //Id_Vet?
            if (veterinariosEncontrado == null)
            {
                return;
            }
            _appContext.veterinarios.Remove(veterinariosEncontrado);
            _appContext.SaveChanges();

        }

        // IEnumerable - me permite retornar una lista de objetos

        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinario()
        {
            return _appContext.veterinarios;
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int id)// (int idPropietario) -- //Id_Vet?
        {
            return _appContext.veterinarios.FirstOrDefault(c => c.id == id);//Id_Vet? -- idPropietario
        }

    }
}