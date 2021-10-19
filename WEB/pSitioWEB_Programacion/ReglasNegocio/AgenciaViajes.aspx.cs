using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibProgramacionSoftware.ReglasNegocio;

namespace pSitioWEB_Programacion.ReglasNegocio
{
    public partial class AgenciaViajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            string CiudadDestino;
            Int16 NumeroPaquetes;
            CiudadDestino = cboDestino.Text;
            NumeroPaquetes = Convert.ToInt16(txtCantidad.Text);
            ClsAgenciaViajes oAgencia = new ClsAgenciaViajes();
            oAgencia.CiudadDestino = CiudadDestino;
            oAgencia.NumeroPaquetes = NumeroPaquetes;

            if (oAgencia.CalcularTotal())
            {
                lblTotalPagar.Text = "$" + oAgencia.TotalPagar.ToString("#,###");
                lblValorAntesDescuento.Text = "$" + oAgencia.ValorAntesDescuento.ToString("#,###");
                lblValorDescuento.Text = "$" + oAgencia.ValorDescuento.ToString("#,###");
                lblValorAntesIVA.Text = "$" + oAgencia.ValorAntesIVA.ToString("#,###");
                lblValorIVA.Text = "$" + oAgencia.ValorIVA.ToString("#,###");

            }
            else
            {
                lblError.Text = oAgencia.Error;

                lblTotalPagar.Text = "";
                lblValorAntesDescuento.Text = "";
                lblValorDescuento.Text = "";
                lblValorAntesIVA.Text = "";
                lblValorIVA.Text = "";
            }
        }
    }
}