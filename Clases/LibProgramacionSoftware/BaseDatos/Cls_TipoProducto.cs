using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaDatos;

namespace LibProgramacionSoftware.BaseDatos
{
    public class Cls_TipoProducto
    {
        /* Se debe compilar la libreria libcomunes, y agregar la referencia del dll al proyecto (solo se hace una vez)
         * luego se agrega el using libcomunes.Capadatos en todas las lases que se requieran manipular datos (CRUD) de la bd
         */
        #region Constructor

        public Cls_TipoProducto()
        {

        }
        #endregion

        #region propiedades/atrubutos

        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        private string SQL; // Para crear la instrucción SQL que va a ejecutar la clase clsConexion
        public string Error { get; private set; }

        #endregion

        #region Metodos
        public bool Insertar()
        {
            // Se crea la consulta parametrizada
            SQL = "INSERT INTO tblTIpoPRoducto (strNombre_TIPR, blnActivo_TIPR)" + "VALUES (@prNombre, @prActivo)";

            // Se crea el objeto conexion 
            clsConexion oConexion = new clsConexion();
            //se pasa la instruccion SQL 
            oConexion.SQL = SQL;
            //Se crean los parametros con el metodo agregar parametro, el nombre del parametro va entre comillas dobles
            //el valor es la propiedad o atributo que tiene la información que se va a asignar al parametro
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);

            //Se invoca el metodo de "Ejecutar Sentencia", porque el insert, el Update y el Delete no devuelven valores
            if (oConexion.EjecutarSentencia())
            {
                //Ejecuto correctamente, se devuelve true
                return true;
            }
            else
            {
                //No pudo ejecutar, se captura el error y se devuelve false
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Actualizar()
        {
            SQL = "UPDATE tblTipoProducto SET " + "strNombre_TIPR = @prNombre, " + "blnActivo_TIPR = @prActivo " +
                "WHERE intCodigo_TIPR = @prCodigo";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);
            oConexion.AgregarParametro("@prCodigo", Codigo);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Borrar()
        {
            SQL = "DELETE FROM tblTipoProducto " + "WHERE intCodigo_TIPR = @prCodigo";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Consultar()
        {
            SQL = "SELECT  strNombre_TIPR, blnActivo_TIPR " + "FROM  tblTipoProducto " + "WHERE  intCodigo_TIPR = @prCodigo";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);
            //Se invoca el metodo consultar, que llena el objeto Reader con la información de la consulta
            //El objeto Reader tiene una propiedad  .hasRows que indica si llegan datos o no de la consulta
            if (oConexion.Consultar())
            {
                //Se hizo la consulta, se debe validar si retornó datos o no 
                if (oConexion.Reader.HasRows)
                {
                
                    //Hay datos en la consulta, lo primero es leer la información con el método .Read() del objeto Reader
                    oConexion.Reader.Read();
                    //para leer los datos, estos quedan almacenados en el objeto Reader, como si fuera un vector 
                    //donde en la posición 0 esta la primer columna de la consulta
                    //para capturar los datos de respuesta de la consulta se utiliza el metodo .GetValue() que es generico,
                    //o los metodos .GetInt32(n), .GetString(n) o .GetDouble(n), etc....

                    Nombre = oConexion.Reader.GetString(0);
                    // Nombre = Convert.ToString(oConexion.Reader.GetValue(0));  -- otra manera de hacerlo
                    // Activo = Convert.ToBoolean(oConexion.Reader.GetValue(1));  -- otra manera de hacerlo

                    Activo = oConexion.Reader.GetBoolean(1);
                    return true;
                }
                else
                {
                    //No Hay datos de la consulta, para el usuario final es un error
                    Error = "No se encontraron datos para el codigo: " + Codigo;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
            
        }
        #endregion

    }
}
