using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia.AppRepositorios;
using PracticaVeterinaria.App.Persistencia;

namespace PracticaVeterinaria.App.Presentacion.Pages
{
    public class ListMascota : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        public IEnumerable<Mascota> mascotas { get; set; }

        public ListMascota()
        {
            this.repositorioMascota = new RepositorioMascota(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }

        public void OnGet()
        {
            mascotas = repositorioMascota.GetAllMascotas();

        }
    }
}
