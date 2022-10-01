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
    public class EditMascota : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        [BindProperty]
        public Mascota MascotaActual { get; set; } = default;
        
        public EditMascota(){
            this.repositorioMascota = new RepositorioMascota(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if(id == null) {
                return NotFound();
            }

            var mascota = this.repositorioMascota.GetMascota(id.Value);
            if(mascota == null) {
                return NotFound();
            }

            MascotaActual = mascota;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if(!ModelState.IsValid) {
                return Page();
            }

            this.repositorioMascota.UpdateMascota(MascotaActual);

            return RedirectToPage("./ListMascota");
        }
    }
}
