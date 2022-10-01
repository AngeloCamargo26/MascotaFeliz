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
    public class DeleteModel : PageModel
    {
         private readonly IRepositorioPropietario repositorioPropietario;
        
        public DeleteModel(){
            this.repositorioPropietario = new RepositorioPropietario(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if(id == null) {
                return NotFound();
            }

            this.repositorioPropietario.DeletePropietario(id.Value);
            
            return RedirectToPage("./ListPropietario");
        }
    }
}
