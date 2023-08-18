using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportWebApp.Classes
{
    public class Taxi : Transporte
    {
        public Taxi(int pasajeros, string numero)
        {
            Tipo = "Taxi";
            CantidadPasajeros = pasajeros;
            NumeroTransporte = numero;
        }

        public override string ObtenerInformacion()
        {
            return $"{Tipo} Nro {NumeroTransporte}: {CantidadPasajeros} pasajeros";
        }
    }
}