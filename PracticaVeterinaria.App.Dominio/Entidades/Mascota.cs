using System;
namespace PracticaVeterinaria.App.Dominio
{
    public class Mascota
    {
        
        public int id { get; set; }
        public string nombre { get; set; }
        public string color { get; set; }
        public string especie { get; set; }
        public string raza { get; set; }
        public int edad { get; set; }
        public string estadoSalud { get; set; }
        public Propietario propietario { get; set; }
        public Veterinario veterinario { get; set; }


    }
}
