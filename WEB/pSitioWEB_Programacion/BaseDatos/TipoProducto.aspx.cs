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
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigo.Text);

            Cls_TipoProducto oTipoProducto = new Cls_TipoProducto();

            oTipoProducto.Codigo = Codigo;

            if (oTipoProducto.Borrar())
            {
                lblError.Text = " Borro correctamente en la Base de Datos el codigo " + Codigo;
            }
            else
            {
                lblError.Text = oTipoProducto.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;
            string Nombre;
            bool Activo;

            Codigo = Convert.ToInt32(txtCodigo.Text);
            Nombre = txtNombre.Text;
            Activo = chkActivo.Checked;

            Cls_TipoProducto oTipoProducto = new Cls_TipoProducto();

            oTipoProducto.Codigo = Codigo;
            oTipoProducto.Nombre = Nombre;
            oTipoProducto.Activo = Activo;

            if (oTipoProducto.Actualizar())
            {
                lblError.Text = " Actualizo correctamente en la Base de Datos el codigo " + Codigo;
            }
            else
            {
                lblError.Text = oTipoProducto.Error;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigo.Text);

            Cls_TipoProducto oTipoProducto = new Cls_TipoProducto();

            oTipoProducto.Codigo = Codigo;

            if (oTipoProducto.Consultar())
            {
                lblError.Text = "";
                txtNombre.Text = oTipoProducto.Nombre;
                chkActivo.Checked = oTipoProducto.Activo;
            }
            else
            {
                lblError.Text = oTipoProducto.Error;
            }
        }
    }
}