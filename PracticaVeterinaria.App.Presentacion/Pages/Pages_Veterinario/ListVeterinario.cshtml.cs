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
    public class ListVeterinario : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public IEnumerable<Veterinario> veterinarios { get; set; }

        public ListVeterinario()
        {
            this.repositorioVeterinario = new RepositorioVeterinario(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }

        public void OnGet()
        {
            veterinarios = repositorioVeterinario.GetAllVeterinario();

        }
    }
}
