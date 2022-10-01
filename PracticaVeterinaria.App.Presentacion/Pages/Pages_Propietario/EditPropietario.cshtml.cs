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
    public class EditModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        [BindProperty]
        public Propietario PropietarioActual { get; set; } = default;
        
        public EditModel(){
            this.repositorioPropietario = new RepositorioPropietario(new PracticaVeterinaria.App.Persistencia.AppRepositorios.AppContext());
        }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if(id == null) {
                return NotFound();
            }

            var propietario = this.repositorioPropietario.GetPropietario(id.Value);
            if(propietario == null) {
                return NotFound();
            }

            PropietarioActual = propietario;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if(!ModelState.IsValid) {
                return Page();
            }

            this.repositorioPropietario.UpdatePropietario(PropietarioActual);

            return RedirectToPage("./ListPropietario");
        }
    }
}
