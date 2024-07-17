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
            try
            {
            DiscosNegocio negocio = new DiscosNegocio();
            Session.Add("listaDiscos", negocio.listarSP());
            dgvDiscos.DataSource = Session["listaDiscos"];
            dgvDiscos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
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
            List<Disco> lista = new List<Disco>();
            if (rdbActivo.Checked)
            {
                lista = ((List<Disco>)Session["listaDiscos"]).FindAll(x => x.Activo.Equals(true) && (x.Titulo.ToUpper().Contains(txtFiltrar.Text.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(txtFiltrar.Text.ToUpper())));
            }
            else if(rdbInactivo.Checked)
            {
                lista = ((List<Disco>)Session["listaDiscos"]).FindAll(x => x.Activo.Equals(false) && (x.Titulo.ToUpper().Contains(txtFiltrar.Text.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(txtFiltrar.Text.ToUpper())));
            }
            else
            {
                lista = ((List<Disco>)Session["listaDiscos"]).FindAll(x => x.Titulo.ToUpper().Contains(txtFiltrar.Text.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
            }
            dgvDiscos.DataSource = lista;
            dgvDiscos.DataBind();
        }
    }
}