using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransportWebApp.Classes;

namespace TransportWebApp
{
    public partial class Default : Page
    {
        List<Transporte> transportes = new List<Transporte>();
  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTipoTransporte.Items.Add(new ListItem("Taxi", "Taxi"));
                ddlTipoTransporte.Items.Add(new ListItem("Ómnibus", "Ómnibus"));
            }
        }

        protected void BtnAgregarTransporte(object sender, EventArgs e)
        {
            string tipoTransporte = ddlTipoTransporte.SelectedValue;

            if (int.TryParse(txtCantidadPasajeros.Text, out int cantidadPasajeros))
            {
                Transporte nuevoTransporte = null;

                if (tipoTransporte == "Taxi")
                {
                    string numeroTransporte = txtNumeroTransporte.Text;
                    if (numeroTransporte.Length == 4)
                    {
                        nuevoTransporte = new Taxi(cantidadPasajeros, numeroTransporte);
                    }
                    else
                    {
                        lblMensaje.Text = "Número de taxi debe tener 4 caracteres.";
                        return;
                    }
                }
                else if (tipoTransporte == "Ómnibus")
                {
                    string numeroTransporte = txtNumeroTransporte.Text;
                    if (numeroTransporte.Length == 3)
                    {
                        nuevoTransporte = new Omnibus(cantidadPasajeros, numeroTransporte);
                    }
                    else
                    {
                        lblMensaje.Text = "Número de ómnibus debe tener 3 caracteres.";
                        return;
                    }
                }
                else
                {
                    lblMensaje.Text = "Tipo de transporte inválido.";
                    return;
                }

                this.transportes.Add(nuevoTransporte);

                if (tipoTransporte == "Taxi" && lstTaxis.Items.Count < 5)
                {
                    lstTaxis.Items.Add(nuevoTransporte.ObtenerInformacion());
                    lblMensaje.Text = "";
                }
                else if (tipoTransporte == "Ómnibus" && lstOmnibus.Items.Count < 5)
                {
                    lstOmnibus.Items.Add(nuevoTransporte.ObtenerInformacion());
                    lblMensaje.Text = "";
                }
                else
                {
                    lblMensaje.Text = "Se ha alcanzado el límite de transportes.";
                }
            }
            else
            {
                lblMensaje.Text = "Cantidad de pasajeros inválida.";
            }
        }


    }
}