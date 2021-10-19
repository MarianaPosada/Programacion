using System;
using LibProgramacionSoftware.BaseDatos;

namespace pSitioWEB_Programacion.BaseDatos
{
    public partial class TipoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string Nombre;
            bool Activo;

            Nombre = txtNombre.Text;
            Activo = chkActivo.Checked;

            Cls_TipoProducto oTipoProducto = new Cls_TipoProducto();

            oTipoProducto.Nombre = Nombre;
            oTipoProducto.Activo = Activo;

            if (oTipoProducto.Insertar())
            {
                lblError.Text = " Inserto correctamente en la Base de Datos";
            }
            else
            {
                lblError.Text = oTipoProducto.Error;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}