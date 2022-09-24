using System;
using PracticaVeterinaria.App.Dominio;
using PracticaVeterinaria.App.Persistencia;

//colecciones de datos, manejdar de manera flexible las consultas en BD
using System.Collections.Generic;
//LINQ 
using System.Linq;

namespace PracticaVeterinaria.App.Persistencia.AppRepositorios
{
    public class RepositorioHistoriasClinicas : IRepositorioHistoriasClinicas
    {

        // readonly -> permite definir un atributo solo para lectura
        private readonly AppContext _appContext;

        public RepositorioHistoriasClinicas(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        
         HistoriaClinica IRepositorioHistoriasClinicas.AddHistoriaClinica(HistoriaClinica historiasClinicas)
        {
            var historiasClinicasAdicionada = _appContext.historiasClinicas.Add(historiasClinicas);
            _appContext.SaveChanges();
            return historiasClinicasAdicionada.Entity;
        }

        void  IRepositorioHistoriasClinicas.DeleteHistoriaClinica(int idhistoriasClinicas)
        {
            var historiasClinicasEncontrada = _appContext.historiasClinicas.FirstOrDefault(c => c.id == idhistoriasClinicas);

            if (historiasClinicasEncontrada == null){
                return;
            }
            // si es null no continua con siguientes lineas
            _appContext.historiasClinicas.Remove(historiasClinicasEncontrada);
            _appContext.SaveChanges();

        }

         HistoriaClinica IRepositorioHistoriasClinicas.GetHistoriaClinica(int idhistoriasClinicas)
        {
            return _appContext.historiasClinicas.FirstOrDefault(c => c.id == idhistoriasClinicas);
        }

         HistoriaClinica IRepositorioHistoriasClinicas.UpdateHistoriaClinica(HistoriaClinica historiasClinicas){

            var historiasClinicasActualizar = _appContext.historiasClinicas.FirstOrDefault(c => c.id == historiasClinicas.id);
            if(historiasClinicasActualizar!=null){

                historiasClinicasActualizar.id = historiasClinicas.id;
                historiasClinicasActualizar.fechaApertura= historiasClinicas.fechaApertura;
                historiasClinicasActualizar.fechaCierre= historiasClinicas.fechaCierre;
                historiasClinicasActualizar.observaciones= historiasClinicas.observaciones;
                historiasClinicasActualizar.mascota=historiasClinicas.mascota;
                _appContext.SaveChanges();
            }
            return historiasClinicasActualizar ;

        }

        IEnumerable<HistoriaClinica> IRepositorioHistoriasClinicas.GetAllHistoriaClinica()
        {
            return _appContext.historiasClinicas;

        }
    }

}




