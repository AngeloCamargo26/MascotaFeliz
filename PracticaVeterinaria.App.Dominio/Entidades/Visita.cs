using System;
namespace PracticaVeterinaria.App.Dominio
{
    public class Visita
    {
        public int id { get; set; }
        public string fechaIngreso { get; set; }
        public string fechaSalida { get; set; }
        public string motivo { get; set; }
        public double temperatura { get; set; }
        public double peso { get; set; }
        public double frecuenciaRespiratoria { get; set; }
        public double frecuenciaCardiaca { get; set; }
        public string estadoAnimo { get; set; }
        public string recomendaciones { get; set; }
        public string medicamentos { get; set; }
        public HistoriaClinica historiasClinicas { get; set; }
        public Propietario propietario { get; set; }

    }
}
