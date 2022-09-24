using System;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia;

//colecciones de datos, manejdar de manera flexible las consultas en BD
using System.Collections.Generic;
//LINQ 
using System.Linq;

namespace PracticaVeterinaria.App.Persistencia.AppRepositorios
{

    public class RepositorioVisita : IRepositorioVisita
    {
        private readonly AppContext _appContext;

        public RepositorioVisita(AppContext appContext)
        {
            _appContext = appContext;
        }

        Visita IRepositorioVisita.AddVisita(Visita visitas)
        {
            var visitasAdicionado = _appContext.visitas.Add(visitas);
            _appContext.SaveChanges();
            return visitasAdicionado.Entity;

        }
        Visita IRepositorioVisita.UpdateVisita(Visita visitas)
        {
            var visitasActualizar = _appContext.visitas.SingleOrDefault(r => r.id == visitas.id); // Cod_Vist?
            if (visitasActualizar != null)
            {
                visitasActualizar.id = visitas.id;  // nombres iguales a las entidades?
                visitasActualizar.fechaIngreso = visitas.fechaIngreso;
                visitasActualizar.fechaSalida = visitas.fechaSalida;
                visitasActualizar.motivo = visitas.motivo;
                visitasActualizar.temperatura = visitas.temperatura;
                visitasActualizar.peso = visitas.peso;
                visitasActualizar.frecuenciaRespiratoria = visitas.frecuenciaRespiratoria;
                visitasActualizar.frecuenciaCardiaca = visitas.frecuenciaCardiaca;
                visitasActualizar.estadoAnimo = visitas.estadoAnimo;
                visitasActualizar.recomendaciones = visitas.recomendaciones;
                visitasActualizar.medicamentos = visitas.medicamentos;
                visitasActualizar.historiasClinicas=visitasActualizar.historiasClinicas;
                visitasActualizar.propietario=visitasActualizar.propietario;
                _appContext.SaveChanges();
            }
            return visitasActualizar;
        }

        void IRepositorioVisita.DeleteVisita(int id)
        {
            var visitasEncontrado = _appContext.visitas.FirstOrDefault(c => c.id == id );// Id_Vist -- idPropietario?
            if (visitasEncontrado == null)
            {
                return;
            }
            _appContext.visitas.Remove(visitasEncontrado);
            _appContext.SaveChanges();

        }

        // IEnumerable - me permite retornar una lista de objetos

        IEnumerable<Visita> IRepositorioVisita.GetAllVisita()
        {
            return _appContext.visitas;
        }

        Visita IRepositorioVisita.GetVisita(int id)//int idPropietario -- Cod_Vist?
        {
            return _appContext.visitas.FirstOrDefault(c => c.id == id);// Cod_Vist -- idPropietario
        }

    }
}