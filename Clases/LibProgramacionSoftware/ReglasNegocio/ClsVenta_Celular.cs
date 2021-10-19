using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibProgramacionSoftware.ReglasNegocio
{
    public class ClsVenta_Celular
    {
        #region
        public ClsVenta_Celular()
        {
            IVA = 0.19;
        }
        #endregion
        #region Propiedades
        public Int32 ValorPlan { private get; set; }
        public Int32 ValorEquipo { private get; set; }
        public double Total { get; private set; }
        public double PorcentajeDesc { get; private set; }
        public double ValorDescuento { get; private set; }
        public double ValorIVA { get; private set; }
        public double ValorAntesIVA { get; private set; }
        public String Error { get; private set; }
        private double IVA;
        private double Vlordescuento;

     

        #endregion
        #region Metodos
        public bool CalcularTotal()
        {
            if (Validar())
            {
                if (CalcularPorcentaje())
                {
                    Total = (ValorPlan * (1-PorcentajeDesc)) + CalcularIvaPlan() + CalcularCuotaEquipo();
                    ValorAntesIVA = CalcularValorAntesIva();
                    ValorDescuento = Vlordescuento;
                    CalcularValorIva();
                   
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        
        private bool CalcularPorcentaje()
        {
            ClsRn_VentaCelular O = new ClsRn_VentaCelular();
            O.ValorEquipo = ValorEquipo;
            O.ValorPlan = ValorPlan;
            if (O.CalcularPorcentajeDescuento())
            {
                PorcentajeDesc = O.PorcentajeDescuento;
                Vlordescuento = (ValorPlan + CalcularValorEquipoSinIva()) * PorcentajeDesc;

                return true;
            }
            else
            {
                Error = O.Error;
                return false;
            }

        }
       
        private double CalcularValorAntesIva()
        {
            return ValorEquipo + ValorPlan - CalcularIvaEquipo();
        }
        private void CalcularValorIva()
        {
            ValorIVA = CalcularIvaPlan() + CalcularIvaEquipo();
        }
        private bool Validar()
        {
            if (ValorPlan < 3000)
            {
                Error = "debe ingresar valores mayores a 3000";
                return false;
            }
            if (ValorEquipo < 100000)
            {
                Error = "debe ingresar valores mayores a 100000";
                return false;
            }
            return true;
        }

        private double CalcularIvaEquipo()
        {
            return (ValorEquipo- CalcularDescuentoEquipo()) - ((ValorEquipo- CalcularDescuentoEquipo()) / (1 + IVA));
        }

        private double CalcularIvaTotal()
        {
            return (ValorPlan + CalcularValorEquipoSinIva() - Vlordescuento ) * IVA;
        }

        private double CalcularValorEquipoSinIva()
        {
            return (ValorEquipo / (1 + IVA)) ;
        }

        private double CalcularDescuentoEquipo()
        {
            return (ValorEquipo / (1 + IVA)) * PorcentajeDesc;
        }

        private double CalcularIvaPlan()
        {
            return (ValorPlan * (1 - PorcentajeDesc)) * IVA;
        }

        private double CalcularCuotaEquipo()
        {
            return ((CalcularValorEquipoSinIva() - CalcularDescuentoEquipo())*(1 + IVA)) / 12;
        }





        #endregion

    }
}
