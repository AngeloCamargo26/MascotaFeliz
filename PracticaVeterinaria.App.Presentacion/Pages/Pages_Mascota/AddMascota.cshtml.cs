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
    public class AddMascota : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        [BindProperty]
        public Mascota NuevaMascota { get; set; } = default;
        
        public AddMascota(){
            this.repositorioMascota = new RepositorioMascota(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }
        public async Task<IActionResult> OnPostAsync() {
            if(!ModelState.IsValid) {
                return Page();
            }
            
            this.repositorioMascota.AddMascota(NuevaMascota);

            return RedirectToPage("./ListMascota");
        }
    }
}
