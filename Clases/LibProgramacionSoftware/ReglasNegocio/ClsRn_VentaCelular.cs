using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibProgramacionSoftware.ReglasNegocio
{
    public class ClsRn_VentaCelular
    {
        #region Constructor


        public ClsRn_VentaCelular()
        {

        }
        #endregion

        #region Propiedades/Atributos
        public Int32 ValorPlan { private get; set; }
        public Int32 ValorEquipo { private get; set; }
        public double PorcentajeDescuento { get; private set; }
        public double ValorDescuento { get; private set; }
        public double ValorIVA { get; private set; }
        public double ValorAntesIVA { get; private set; }
        public String Error { get; private set; }

        #endregion
        #region
        public bool CalcularPorcentajeDescuento()
        {
            if (Validar())
            {
             
                XmlDocument oDocumento = new XmlDocument();
                
                oDocumento.Load(@"C:\Users\Mariana\Documents\ITM\2021-2\Proyectos Programaciòn de Software\Clases\LibProgramacionSoftware\XML2\xml_Venta_Celular.xml");

                string ConsultaXML = "//Descuento[@MIN<='" + ValorPlan + "' and @MAX>" + ValorPlan + " and @EMIN<=" +
                                      ValorEquipo + " and @EMAX>" + ValorEquipo + "]";

                XmlNodeList oNodos = oDocumento.SelectNodes(ConsultaXML);
               
                if (oNodos.Count == 0)
                {
                    Error = "No se obtuvo respuesta, comuníquese con el administrador";
                    return false;
                }
                else
                {
                    if (oNodos.Count > 1)
                    {
                        Error = "Se generaron más respuestas de las esperadas, comuníquese con el administrador";
                        return false;
                    }
                    else
                    {
                        
                        PorcentajeDescuento = Convert.ToDouble(oNodos[0].InnerText) / 100;
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        private bool Validar()
        {
            if (ValorPlan<3000)
            {
                Error = "debe ingresar valores mayores a 3000";
                return false;
            }
            if (ValorEquipo<100000)
            {
                Error = "debe ingresar valores mayores a 100000";
                return false;
            }
            return true;
        }
        #endregion
    }
   

}
