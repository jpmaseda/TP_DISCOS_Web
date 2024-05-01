using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Web.Configuration;

namespace Discos_web
{
    public partial class AgregarDisco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    EstiloNegocio estiloNegocio = new EstiloNegocio();
                    TipoEdicionNegocio edicionNegocio = new TipoEdicionNegocio();
                    ddlEstilo.DataSource = estiloNegocio.listar();
                    ddlEstilo.DataValueField = "Id";
                    ddlEstilo.DataTextField = "Descripcion";
                    ddlEstilo.DataBind();
                    ddlEdicion.DataSource = edicionNegocio.listar();
                    ddlEdicion.DataValueField = "Id";
                    ddlEdicion.DataTextField = "Descripcion";
                    ddlEdicion.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void bntAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                Disco x = new Disco();
                x.Titulo = txtTitulo.Text;
                x.CantidadCanciones = int.Parse(txtCanciones.Text);
                x.FechaLanzamiento = DateTime.Parse(txtLanzamiento.Text);
                x.UrlImagenTapa = txtUrlImagen.Text;
                x.Estilo = new Estilo();
                x.Estilo.Id = int.Parse(ddlEstilo.SelectedValue);
                x.Estilo.Descripcion = ddlEstilo.SelectedItem.Text;
                x.Edicion = new Edicion();
                x.Edicion.Id = int.Parse(ddlEdicion.SelectedValue);
                x.Edicion.Descripcion = ddlEdicion.SelectedItem.Text;

                //negocio.agregar(x);
                List<Disco> temporal = (List<Disco>)Session["listaDiscos"];
                temporal.Add(x);
                Response.Redirect("DiscosLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}