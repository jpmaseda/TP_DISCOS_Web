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
                    Session.Add("error", ex);
                    throw;
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
            dgvDiscos.PageIndex = e.NewPageIndex;
            dgvDiscos.DataBind();
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            List<Disco> lista = ((List<Disco>)Session["listaDiscos"]).FindAll(x => x.Titulo.ToUpper().Contains(txtFiltrar.Text.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
            dgvDiscos.DataSource = lista;
            dgvDiscos.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvDiscos.DataSource = Session["listaDiscos"];
            dgvDiscos.DataBind();
            txtFiltrar.Text = "";
            txtFiltroAvanzado.Text = "";
            ddlCampo.Text = "Título";
            ddlCriterio.Items.Clear();
            ddlEstado.Text = "Todos";
            lblFecha.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int valorSalida = 1;
            lblFecha.Text = "";
            if (ddlCampo.Text == "Año de lanzamiento" && !int.TryParse(txtFiltroAvanzado.Text, out valorSalida))
            {
                lblFecha.Text = "El filtro debe contener números.";
                return;
            }
            if (int.Parse(txtFiltroAvanzado.Text) >= 2079)
            {
                lblFecha.Text = "El año debe ser menor al 2079.";
                return;
            }
            else if (int.Parse(txtFiltroAvanzado.Text) <= 1900)
            {
                lblFecha.Text = "El año debe ser mayor al 1900.";
                return;
            }
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                List<Disco> lista = (List<Disco>)negocio.filtrar(ddlCampo.Text, ddlCriterio.Text, txtFiltroAvanzado.Text, ddlEstado.Text);
                dgvDiscos.DataSource = lista;
                dgvDiscos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
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