using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace Discos_web
{
    public partial class DicosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaDiscos"] == null)
            {
                DiscosNegocio negocio = new DiscosNegocio();
                Session.Add("listaDiscos", negocio.listarSP());
            }
            dgvDiscos.DataSource = Session["listaDiscos"];
            dgvDiscos.DataBind();
        }
    }
}