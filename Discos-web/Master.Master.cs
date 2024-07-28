using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Discos_web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page is _default || Page is Login || Page is Registro)
            {
                return;
            }
            else
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session["usuario"] = null;
                Response.Redirect("login.aspx");
            }
        }
    }
}