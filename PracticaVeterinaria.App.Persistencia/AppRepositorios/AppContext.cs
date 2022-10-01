using Microsoft.EntityFrameworkCore;
using PracticaVeterinaria.App.Dominio;

//Antes de la migración
namespace PracticaVeterinaria.App.Persistencia.AppRepositorios

//Para trabajar después de migración con conexión a Front-end
//namespace PracticaVeterinaria.App.Persistencia.AppRepositorios

{
    public class AppContext : DbContext
    {
        public DbSet<Propietario> propietarios { get; set; }
        public DbSet<Veterinario> veterinarios { get; set; }
        public DbSet<Mascota> mascotas { get; set; }
        public DbSet<HistoriaClinica> historiasClinicas { get; set; }
        public DbSet<Visita> visitas { get; set; }



        // implementar todas las clases

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PracticaVeterinaria.Data");
            }
        }

    }
}