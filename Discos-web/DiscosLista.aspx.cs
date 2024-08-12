using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Discos_web
{
    public partial class DicosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["listaDiscos"] == null)
            //{
            //    DiscosNegocio negocio = new DiscosNegocio();
            //    Session.Add("listaDiscos", negocio.listarSP());
            //}
            //dgvDiscos.DataSource = Session["listaDiscos"];
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Necesitas permisos de admin para ver esta página.");
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                try
                {
                    DiscosNegocio negocio = new DiscosNegocio();
                    EstiloNegocio estilos = new EstiloNegocio();
                    Session.Add("listaDiscos", negocio.listarSP());
                    Session.Add("listaEstilos", estilos.listar());
                    dgvDiscos.DataSource = Session["listaDiscos"];
                    dgvDiscos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void dgvDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvDiscos.SelectedDataKey.Value.ToString();
            Session.Add("Id", id);
            Response.Redirect("FormularioDisco.aspx", false);
            //Response.Redirect("FormularioDisco.aspx?Id=" + id, false);
        }

        protected void dgvDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["listaFiltrada"] != null)
                dgvDiscos.DataSource = Session["listaFiltrada"];
            else
                dgvDiscos.DataSource = Session["listaDiscos"];
            dgvDiscos.PageIndex = e.NewPageIndex;
            dgvDiscos.DataBind();
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            List<Disco> lista = ((List<Disco>)Session["listaDiscos"]).FindAll(x => x.Titulo.ToUpper().Contains(txtFiltrar.Text.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
            if(txtFiltrar.Text == "")
                dgvDiscos.PageSize = 5;
            else
                dgvDiscos.PageSize = 20;
            dgvDiscos.DataSource = lista;
            dgvDiscos.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Session["listaFiltrada"] = null;
            dgvDiscos.PageSize = 5;
            dgvDiscos.DataSource = Session["listaDiscos"];
            dgvDiscos.DataBind();
            txtFiltrar.Text = "";
            txtFiltroAvanzado.Text = "";
            ddlCampo.Text = "Título";
            ddlCriterio.Items.Clear();
            ddlCriterio.Items.Add("Comienza con");
            ddlCriterio.Items.Add("Termina con");
            ddlCriterio.Items.Add("Contiene");
            ddlCriterio.SelectedIndex = 0;
            ddlEstado.Text = "Todos";
            lblFecha.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvDiscos.PageSize = 5;
            int valorSalida = 1;
            lblFecha.Text = "";
            if (ddlCampo.Text == "Año de lanzamiento")
            {
                if (!int.TryParse(txtFiltroAvanzado.Text, out valorSalida))
                {
                    lblFecha.Text = "El filtro debe contener números.";
                    return;
                }
                else if (int.Parse(txtFiltroAvanzado.Text) >= 2079)
                {
                    lblFecha.Text = "El año debe ser menor al 2079.";
                    return;
                }
                else if (int.Parse(txtFiltroAvanzado.Text) <= 1900)
                {
                    lblFecha.Text = "El año debe ser mayor al 1900.";
                    return;
                }
            }
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                List<Disco> lista = (List<Disco>)negocio.filtrar(ddlCampo.Text, ddlCriterio.Text, txtFiltroAvanzado.Text, ddlEstado.Text);
                Session.Add("listaFiltrada", lista);
                dgvDiscos.DataSource = lista;
                dgvDiscos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Título")
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
            if (ddlCampo.SelectedItem.ToString() == "Año de lanzamiento")
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Es");
            }
            if (ddlCampo.SelectedItem.ToString() == "Estilo")
            {
                ddlCriterio.DataSource = (List<Estilo>)Session["listaEstilos"];
                ddlCriterio.DataBind();
            }
        }
    }
}