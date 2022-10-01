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
    public class AddVeterinario : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        [BindProperty]
        public Veterinario NuevoVeterinario { get; set; } = default;
        
        public AddVeterinario(){
            this.repositorioVeterinario = new RepositorioVeterinario(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }
        public async Task<IActionResult> OnPostAsync() {
            if(!ModelState.IsValid) {
                return Page();
            }
            
            this.repositorioVeterinario.AddVeterinario(NuevoVeterinario);

            return RedirectToPage("./ListVeterinario");
        }
    }
}
