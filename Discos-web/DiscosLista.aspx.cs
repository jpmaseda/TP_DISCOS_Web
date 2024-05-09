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
            List<Disco> lista = negocio.listarSP();
            Session.Add("listaDiscos", lista);
            dgvDiscos.DataSource = lista;
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
    }
}