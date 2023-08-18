using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportWebApp.Classes
{
    public abstract class Transporte
    {
        public string Tipo { get; set; }
        public int CantidadPasajeros { get; set; }

        public string NumeroTransporte { get; set; }

        public abstract string ObtenerInformacion();
    }
}