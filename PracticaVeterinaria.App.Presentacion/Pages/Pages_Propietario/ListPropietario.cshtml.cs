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
    public class ListModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        public IEnumerable<Propietario> propietarios { get; set; }

        public ListModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }

        public void OnGet()
        {
            propietarios = repositorioPropietario.GetAllPropietarios();

        }
    }
}
