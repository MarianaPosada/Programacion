using System;

namespace LibProgramacionSoftware.ReglasNegocio
{
    public class ClsVentaMinutos
    {
        #region Constructor

        public ClsVentaMinutos()
        {
            ValorDatos = 150;
            ValorMinuto = 30;
            ValorRecarga = 0;
            ValorReferenciaDatos = 1000;
        }
        #endregion
        #region Propiedades/Atributos
        public int ValorRecarga { private get; set; }
        public string NumeroCelular { private get; set; }
        public double PorcentajeMinExtra { get; private set; }
        public int MinutosExtra { get; private set; }
        public int MinutosComprados { get; private set; }
        public int MinutosTotales { get; private set; }
        public short DatosComprados { get; private set; }
        public short DatosExtra { get; private set; }
        public short DatosTotales { get; private set; }
        private readonly short ValorMinuto;
        private readonly short ValorDatos;
        private readonly short ValorReferenciaDatos;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool CalcularTotal()
        {
            if (Validar())
            {
                MinutosComprados = ValorRecarga / ValorMinuto;
                DatosComprados = Convert.ToInt16(ValorRecarga / ValorReferenciaDatos * ValorDatos);
                if (CalcularExtra())
                {
                    MinutosTotales = MinutosComprados + MinutosExtra;
                    DatosTotales = Convert.ToInt16(DatosComprados + DatosExtra);
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
        private bool Validar()
        {
            if (ValorRecarga < 1000 || ValorRecarga > 60000)
            {
                Error = "El valor de la recarga no es válido, por favor ingrese un número entre $1.000 y $60.000";
                return false;
            }
            if (string.IsNullOrEmpty(NumeroCelular))
            {
                Error = "No definió el número de celular";
                return false;
            }
            return true;
        }
        private bool CalcularExtra()
        {
            //Se debe calcular el porcentaje extra
            if (CalcularPorcentajeExtra())
            {
                MinutosExtra = Convert.ToInt32(MinutosComprados * PorcentajeMinExtra);
                DatosExtra = Convert.ToInt16(DatosComprados * PorcentajeMinExtra);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CalcularPorcentajeExtra()
        {
            //Invoca la regla de negocio
            ClsRN_PromocionMinutos oPromocion = new ClsRN_PromocionMinutos
            {
                ValorRecarga = ValorRecarga,
                NumeroCelular = NumeroCelular
            };

            if (oPromocion.CalcularPromocion())
            {
                PorcentajeMinExtra = oPromocion.PorcentajeMinExtra;
                return true;
            }
            else
            {
                Error = oPromocion.Error;
                return false;
            }
        }
        #endregion
    }
}
