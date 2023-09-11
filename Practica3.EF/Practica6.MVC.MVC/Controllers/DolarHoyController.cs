using Practica7.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Practica7.WebApi.Controllers
{
    public class DolarHoyController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var list = await GetApiDolar();

            foreach (var dolar in list)
            {
                dolar.FechaActualizacion = FormatearFecha(dolar.FechaActualizacion);
            }

            return View(list);
        }

        private string FormatearFecha(string fechaIso)
        {
            if (DateTime.TryParse(fechaIso, out DateTime fecha))
            {
                return fecha.ToString("dd-MM-yyyy"); // Formato "DD-MM-AAAA"
            }
            return fechaIso;
        }

        public async Task<List<DolarHoyView>> GetApiDolar()
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://dolarapi.com/v1/dolares");
            HttpResponseMessage message = await client.GetAsync(uri);
            List<DolarHoyView> list = null;
            if (message.IsSuccessStatusCode)
            {
                var content = await message.Content.ReadAsStringAsync();
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DolarHoyView>>(content);
            }
            return list;
        }
    }
}
