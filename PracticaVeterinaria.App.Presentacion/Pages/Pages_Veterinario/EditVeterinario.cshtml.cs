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
    public class EditVeterinario : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        [BindProperty]
        public Veterinario VeterinarioActual { get; set; } = default;
        
        public EditVeterinario(){
            this.repositorioVeterinario = new RepositorioVeterinario(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if(id == null) {
                return NotFound();
            }

            var veterinario = this.repositorioVeterinario.GetVeterinario(id.Value);
            if(veterinario == null) {
                return NotFound();
            }

            VeterinarioActual = veterinario;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if(!ModelState.IsValid) {
                return Page();
            }

            this.repositorioVeterinario.UpdateVeterinario(VeterinarioActual);

            return RedirectToPage("./ListVeterinario");
        }
    }
}
