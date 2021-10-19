using System;

namespace LibProgramacionSoftware.ClasesBasicas
{
    public class ClsVentaProducto
    {
        #region Propiedades

        public Int16 Cantidad { private get; set; }
        public double ValorUnitario { private get; set; }
        public double Total { get; private set; }
        public double ValorIVA { get; private set; }
        public double Subtotal { get; private set; }
        private double PorcentajeIVA;
        public string Error { get; private set; }

        #endregion

        #region Metodos
        public void CalcularTotal()
        {
            Total = ValorUnitario * Cantidad;
            Subtotal = CalcularSubtotal();
            CalcularIVA();

        }
        public void CalcularIVA()
        {
            ValorIVA = Total - Subtotal;

        }
        public double CalcularSubtotal()
        {
            PorcentajeIVA = 0.19;
            return (Total / (1 + PorcentajeIVA));
        }
        #endregion
    }
}
