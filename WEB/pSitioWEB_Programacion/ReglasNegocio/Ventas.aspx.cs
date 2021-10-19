using LibProgramacionSoftware.ReglasNegocio;
using System;

namespace pSitioWEB_Programacion.ReglasNegocio
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            int ValorPlan, ValorEquipo;
            ValorPlan = Convert.ToInt32(TextBox2.Text);
            ValorEquipo = Convert.ToInt32(TextBox1.Text);

            ClsVenta_Celular C = new ClsVenta_Celular
            {
                ValorPlan = ValorPlan,
                ValorEquipo = ValorEquipo
            };
            if (C.CalcularTotal())
            {
                lblTotal.Text = C.Total.ToString();
                lblPorcentaje.Text = C.PorcentajeDesc.ToString();
                lblValorIVA.Text = C.ValorIVA.ToString();
                lblVlorantIVA.Text = C.ValorAntesIVA.ToString();
                lblValorDesc.Text = C.ValorDescuento.ToString();
                lblError.Text = "";
            }
            else
            {
                lblTotal.Text = "";
                lblPorcentaje.Text = "";
                lblValorIVA.Text = "";
                lblVlorantIVA.Text = "";
                lblValorDesc.Text = "";
                lblError.Text = C.Error.ToString();

            }

        }
    }
}