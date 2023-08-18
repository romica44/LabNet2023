using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportWebApp.Classes
{
    public class Omnibus : Transporte
    {
     
        public Omnibus(int pasajeros, string numero)
        {
            Tipo = "Ómnibus";
            CantidadPasajeros = pasajeros;
            NumeroTransporte = numero;

        }

        public override string ObtenerInformacion()
        {
            return $"{Tipo} Nro {NumeroTransporte}: {CantidadPasajeros} pasajeros";
        }
    }
}