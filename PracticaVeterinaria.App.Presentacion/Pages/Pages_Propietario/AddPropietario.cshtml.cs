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
    public class AddModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        [BindProperty]
        public Propietario NuevoPropietario { get; set; } = default;
        
        public AddModel(){
            this.repositorioPropietario = new RepositorioPropietario(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }
        public async Task<IActionResult> OnPostAsync() {
            if(!ModelState.IsValid) {
                return Page();
            }
            
            this.repositorioPropietario.AddPropietario(NuevoPropietario);

            return RedirectToPage("./ListPropietario");
        }
    }
}
