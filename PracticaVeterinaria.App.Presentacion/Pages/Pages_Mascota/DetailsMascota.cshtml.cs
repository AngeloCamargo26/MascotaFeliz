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
    public class DeleteMascota : PageModel
    {
         private readonly IRepositorioMascota repositorioMascota;
        
        public DeleteMascota(){
            this.repositorioMascota = new RepositorioMascota(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if(id == null) {
                return NotFound();
            }

            this.repositorioMascota.DeleteMascota(id.Value);
            
            return RedirectToPage("./ListMascota");
        }
    }
}
