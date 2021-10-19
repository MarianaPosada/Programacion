using LibProgramacionSoftware.ReglasNegocio;
using System;

namespace pSitioWEB_Programacion.ReglasNegocio
{
    public partial class VentaMinutosDatosWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            int ValorRecarga;
            string NumeroCelular;

            ValorRecarga = Convert.ToInt32(cboRecarga.SelectedValue);
            NumeroCelular = txtNumeroCelular.Text;

            ClsVentaMinutos oVentaMinutos = new ClsVentaMinutos
            {
                NumeroCelular = NumeroCelular,
                ValorRecarga = ValorRecarga
            };

            if (oVentaMinutos.CalcularTotal())
            {
                if (oVentaMinutos.DatosExtra <= 0)
                {
                    lblDatosAdicionales.Text = "";
                }
                else
                {
                    lblDatosAdicionales.Text = oVentaMinutos.DatosExtra.ToString("#,###") + " Mb";
                }
                lblDatosComprados.Text = oVentaMinutos.DatosComprados.ToString("#,###") + " Mb";
                lblTotalDatos.Text = oVentaMinutos.DatosTotales.ToString("#,###") + " Mb";
                lblMinutosAdicionales.Text = oVentaMinutos.MinutosExtra.ToString("#,###");
                lblMinutosComprados.Text = oVentaMinutos.MinutosComprados.ToString("#,###");
                lblTotalMinutos.Text = oVentaMinutos.MinutosTotales.ToString("#,###");

                lblError.Text = "";
            }
            else
            {
                lblError.Text = oVentaMinutos.Error;

                lblDatosAdicionales.Text = "";
                lblDatosComprados.Text = "";
                lblTotalDatos.Text = "";
                lblMinutosAdicionales.Text = "";
                lblMinutosComprados.Text = "";
                lblTotalMinutos.Text = "";
            }
        }
    }
}
