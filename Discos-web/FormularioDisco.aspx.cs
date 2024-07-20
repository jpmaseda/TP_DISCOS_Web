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
        public bool CheckConfirmar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckConfirmar = false;
            btnEliminar.Enabled = false;
            btnInactivar.Enabled = false;
            if (txtId.Text != "")
                btnEliminar.Enabled = true;
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
                Response.Redirect("Error.aspx", false);
                //redireccionar a pantalla de error
            }
            if (Session["Id"] != null)
            {
                btnAceptar.Text = "Modificar";
                btnEliminar.Enabled = true;
                btnInactivar.Enabled = true;
                List<Disco> temporal = (List<Disco>)Session["listaDiscos"];
                int id = int.Parse(Session["Id"].ToString());
                Disco seleccionado = temporal.Find(x => x.Id == id);
                Session.Add("discoSeleccionado", seleccionado); 
                txtId.Text = seleccionado.Id.ToString();
                txtTitulo.Text = seleccionado.Titulo;
                txtCanciones.Text = seleccionado.CantidadCanciones.ToString();
                txtLanzamiento.Text = seleccionado.FechaLanzamiento.ToString("yyyy-MM-dd");
                txtUrlImagen.Text = seleccionado.UrlImagenTapa.ToString();
                ddlEstilo.SelectedValue = seleccionado.Estilo.Id.ToString();
                ddlEdicion.SelectedValue = seleccionado.Edicion.Id.ToString();
                imgTapa.ImageUrl = txtUrlImagen.Text;
                if (seleccionado.Activo == false)
                    btnInactivar.Text = "Reactivar";
                Session["Id"] = null;
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                Disco nuevo = new Disco();
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
                if (txtId.Text != "")
                {
                    nuevo.Id = int.Parse(txtId.Text.ToString());
                    negocio.modificarSP(nuevo);
                }
                else
                    negocio.agregarSP(nuevo);
                //List<Disco> temporal = (List<Disco>)Session["listaDiscos"];
                //temporal.Add(nuevo);
                Response.Redirect("DiscosLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgTapa.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnConfEliminar_Click(object sender, EventArgs e)
        {
            if (chkConfimarEliminar.Checked)
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
                    Response.Redirect("Error.aspx", false);
                }
            }

        }
        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                Disco seleccionado = (Disco)Session["discoSeleccionado"];
                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
                //if (btnInactivar.Text == "Reactivar")
                //    negocio.eliminarLogico(int.Parse(txtId.Text.ToString()), true);
                //else
                //    negocio.eliminarLogico(int.Parse(txtId.Text.ToString()));
                Response.Redirect("DiscosLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CheckConfirmar = true;
        }
    }
}