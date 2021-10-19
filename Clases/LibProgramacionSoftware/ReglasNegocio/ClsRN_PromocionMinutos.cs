using System;
using System.Globalization;
using System.Xml;

namespace LibProgramacionSoftware.ReglasNegocio
{
    public class ClsRN_PromocionMinutos
    {
        #region Constructor
        public ClsRN_PromocionMinutos()
        {
            ValorRecarga = 0;
        }

        #endregion
        #region Propiedades/Atributos
        public Int32 ValorRecarga { private get; set; }
        public string NumeroCelular { private get; set; }
        public double PorcentajeMinExtra { get; private set; }
        public string Error { get; private set; }
        private string DiaSemana;
        private string UltimoDigito;
        #endregion
        #region Metodos
        public bool CalcularPromocion()
        {
            if (Validar())
            {
                CalcularDiaSemana();
                CalcularUltimoDigito();
                try
                {
                    XmlDocument oDocumento = new XmlDocument();
                    oDocumento.Load(@"C:\Users\Mariana\Documents\ITM\2021-2\Proyectos Programaciòn de Software\Clases\LibProgramacionSoftware\XML2\xml_VentaMinutos.xml");
                    string ConsultaXML = "//PROMOCION[@DIA='" + DiaSemana.ToUpper() + "' and @DIGITO=" + UltimoDigito + " and @MIN<=" +
                                      ValorRecarga + " and @MAX>=" + ValorRecarga + "]";

                    XmlNodeList oNodos = oDocumento.SelectNodes(ConsultaXML); 
                    if (oNodos.Count == 0)
                    {
                        Error = "No se encontro una respuesta valida, consulte por favor con el administrador del sistema";
                        return false;
                    }
                    else
                    {
                        if (oNodos.Count > 1)
                        {
                            Error = "Se encontraron varias respuestas, por favor consulte con el administrador del sistema";
                            return false;
                        }
                        else
                        {
                            PorcentajeMinExtra = Convert.ToDouble(oNodos[0].InnerText) / 100;
                            return true;
                        }
                    }
                    
                }
                catch(Exception ex)
                {
                    Error = ex.Message;
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
                Error = " El valor de la Recarga no es valido, debe ingresar un valor entre 1000 y 60000";
                return false;
            }
            if (string.IsNullOrEmpty(NumeroCelular))
            {
                Error = "No ha definido su numero celular";
                return false;
            }
            return true;
        }
         
        private void CalcularUltimoDigito()
        {
            UltimoDigito = NumeroCelular.Substring(NumeroCelular.Length - 1);
        }
        private void CalcularDiaSemana()
        {
            //Para encontrar el día de la semana en español, o en otro idioma que no sea en inglés, se debe utilizar
            //la librería CultureInfo
            CultureInfo oCultura = new CultureInfo("Es-Es");
            DiaSemana = oCultura.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);

        }
        #endregion
    }
}
