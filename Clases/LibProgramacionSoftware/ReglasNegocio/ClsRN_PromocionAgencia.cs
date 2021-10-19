using System;
using System.Xml;

namespace LibProgramacionSoftware.ReglasNegocio
{
    public class ClsRN_PromocionAgencia
    {

        #region Constructor
        public ClsRN_PromocionAgencia()
        {

        }
        #endregion

        #region Propiedades/Atributos
        public String TipoDestino { private get; set; }
        public Int16 NumeroPaquetes { private get; set; }
        public double PorcentajeDescuento { get; private set; }
        public String Error { get; private set; }
        #endregion
        #region Metodos
        public bool CalcularPorcentajeDescuento()
        {
            if (Validar())
            {
                // calcula el porcentaje de descuento
                //return true;
                //lo quito el maestro para continuar, con lo que se debe hacer

                try
                {
                    //Se crea el objeto
                    XmlDocument oDocumento = new XmlDocument();

                    //Se carga el archivoxml,con el metodo.load()
                    oDocumento.Load(@"C:\Users\Mariana\Documents\ITM\2021-2\Proyectos Programaciòn de Software\Clases\LibProgramacionSoftware\XML\xmlRn_AgenciaVIajes.xml");

                    // Se genera la consulta
                    string ConsultaXML = "/RN_AGENCIA_VIAJES/DESCUENTO_TIPO_DESTINO/DESCUENTO[@TIPO_DESTINO='" + TipoDestino.ToUpper() + "' and" +
                        "@MIN<=" + NumeroPaquetes + "and @MAX >=" + NumeroPaquetes + "]";
                    XmlNodeList oNodos = oDocumento.SelectNodes(ConsultaXML);
                    if (oNodos.Count == 0)
                    {
                        Error = " No se obtuvo respuesta, cominiquese con el administrador ";
                        return false;
                    }
                    else
                    {
                        if (oNodos.Count > 1)
                        {
                            Error = " Se generaron mas respuestas de las esperadas, cominiquese con el administrador ";
                            return false;
                        }
                        else
                        {
                            //hubo una respuesta que es la esperada, y se calcula el porcentaje de descuento 
                            PorcentajeDescuento = Convert.ToDouble(oNodos[0].InnerText) / 100;
                            return true;
                        }
                    }
                }
                // el try y el catch significa que de esa linea a esa linea se procurara de ejecutarar y en caso de haber error
                //se capturara esa excepción en un objeto llamado ex
                catch (Exception ex)
                {
                    Error = ex.Message;
                    return false;   //se pone este return false siempre usando try y catch.
                }

            }
            else
            {
                return false;
            }
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(TipoDestino))
            {
                Error = "No Definio el tipo de Destino";
                return false;
            }
            if (NumeroPaquetes < 1 || NumeroPaquetes > 20)
            {
                Error = "El Numweo de Paquetes debe estar entre 1 y 20";
                return false;
            }
            return true;

        }
        #endregion

    }
}

