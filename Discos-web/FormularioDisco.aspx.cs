using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Web.Configuration;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace Discos_web
{
    public partial class AgregarDisco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            //txtLanzamiento.Attributes.Add("onBlur", "__doPostBack('txtLanzamiento','');");
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
                //redireccionar a pantalla de error
            }
            if (Session["Id"] != null)
            {
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                List<Disco> temporal = (List<Disco>)Session["listaDiscos"];
                int id = int.Parse(Session["Id"].ToString());
                Disco seleccionado = temporal.Find(x => x.Id == id);
                txtId.Text = seleccionado.Id.ToString();
                txtTitulo.Text = seleccionado.Titulo;
                txtCanciones.Text = seleccionado.CantidadCanciones.ToString();
                txtLanzamiento.Text = seleccionado.FechaLanzamiento.ToString("yyyy-MM-dd");
                txtUrlImagen.Text = seleccionado.UrlImagenTapa.ToString();
                ddlEstilo.SelectedValue = seleccionado.Estilo.Id.ToString();
                ddlEdicion.SelectedValue = seleccionado.Edicion.Id.ToString();
                Session["Id"] = null;
                imgTapa.ImageUrl = txtUrlImagen.Text;
            }
            //if (Request.QueryString["Id"] != null)
            //{
            //    List<Disco> temporal = (List<Disco>)Session["listaDiscos"];
            //    int id = int.Parse(Request.QueryString["Id"]);
            //    Disco seleccionado = temporal.Find(x => x.Id == id);
            //    if (seleccionado == null)
            //    {
            //        txtId.Text = "";
            //        return;
            //    }
            //    txtId.Text = seleccionado.Id.ToString();
            //    txtTitulo.Text = seleccionado.Titulo;
            //}
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                Disco nuevo = new Disco();
                //nuevo.Id = int.Parse(txtId.Text.ToString());
                nuevo.Titulo = txtTitulo.Text;
                nuevo.CantidadCanciones = int.Parse(txtCanciones.Text);
                nuevo.FechaLanzamiento = DateTime.Parse(txtLanzamiento.Text);
                //Valida rango posible para smalldatetime
                if (DateTime.Parse(txtLanzamiento.Text) < DateTime.Parse("1900 / 01 / 01"))
                {
                    lblLanzamiento.Text = "La fecha debe ser mayor al 01/01/1900";
                    return;
                }
                else if (DateTime.Parse(txtLanzamiento.Text) > DateTime.Parse("2079 / 06 / 06"))
                {
                    lblLanzamiento.Text = "La fecha debe ser menor al 06/06/2079";
                    return;
                }
                nuevo.UrlImagenTapa = txtUrlImagen.Text;
                nuevo.Estilo = new Estilo();
                nuevo.Edicion = new Edicion();
                nuevo.Estilo.Id = int.Parse(ddlEstilo.SelectedValue);
                nuevo.Edicion.Id = int.Parse(ddlEdicion.SelectedValue);
                //nuevo.Estilo.Descripcion = ddlEstilo.SelectedItem.Text;
                //nuevo.Edicion.Descripcion = ddlEdicion.SelectedItem.Text;

                negocio.agregarSP(nuevo);
                //List<Disco> temporal = (List<Disco>)Session["listaDiscos"];
                //temporal.Add(nuevo);
                Response.Redirect("DiscosLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgTapa.ImageUrl = txtUrlImagen.Text;            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                negocio.eliminarSP(int.Parse(txtId.Text));
                Response.Redirect("DiscosLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
        protected void txtLanzamiento_TextChanged(object sender, EventArgs e)
        {
            //Valida rango posible para smalldatetime
            if (DateTime.Parse(txtLanzamiento.Text) < DateTime.Parse("1900 / 01 / 01"))
                lblLanzamiento.Text = "La fecha debe ser mayor al 01/01/1900";
            else if (DateTime.Parse(txtLanzamiento.Text) > DateTime.Parse("2079 / 06 / 06"))
                lblLanzamiento.Text = "La fecha debe ser menor al 06/06/2079";
        }      
    }
}