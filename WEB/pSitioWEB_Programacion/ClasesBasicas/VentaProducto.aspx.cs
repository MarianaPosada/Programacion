using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibProgramacionSoftware.ClasesBasicas;

namespace pSitioWEB_Programacion.ClasesBasicas
{
    public partial class VentaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Int16 Cantidad;
            double ValorUnitario;

            Cantidad = Convert.ToInt16(txtCantidad.Text);
            ValorUnitario = Convert.ToDouble(txtValorUnitario.Text);

            ClsVentaProducto oVentaProducto = new ClsVentaProducto();

            oVentaProducto.Cantidad = Cantidad;
            oVentaProducto.ValorUnitario = ValorUnitario;
            oVentaProducto.CalcularTotal();

            LblSubtotal.Text = "$" + oVentaProducto.Subtotal.ToString("#,###");
            LblValorIVA.Text = "$" + oVentaProducto.ValorIVA.ToString("#,###");
            LblTotalP.Text = "$" + oVentaProducto.Total.ToString("#,###");
        }
    }
}