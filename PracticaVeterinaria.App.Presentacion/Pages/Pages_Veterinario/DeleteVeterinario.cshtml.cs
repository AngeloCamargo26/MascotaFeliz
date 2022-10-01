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
    public class DeleteVeterinario : PageModel
    {
         private readonly IRepositorioVeterinario repositorioVeterinario;
        
        public DeleteVeterinario(){
            this.repositorioVeterinario = new RepositorioVeterinario(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if(id == null) {
                return NotFound();
            }

            this.repositorioVeterinario.DeleteVeterinario(id.Value);
            
            return RedirectToPage("./ListVeterinario");
        }
    }
}
