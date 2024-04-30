using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Discos_web
{
    public partial class _default : System.Web.UI.Page
    {
        public List<Disco> ListaDiscos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            ListaDiscos = negocio.listarSP();
        }
    }
}