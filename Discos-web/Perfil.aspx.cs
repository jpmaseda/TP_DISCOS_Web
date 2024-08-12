using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Discos_web
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    txtEmail.Text = ((Usuario)Session["usuario"]).Email;
                    if (((Usuario)Session["usuario"]).User != null)
                        txtNombreUsuario.Text = ((Usuario)Session["usuario"]).User;
                    if (((Usuario)Session["usuario"]).FechaNacimiento != null)
                        txtFechaNacimiento.Text = ((Usuario)Session["usuario"]).FechaNacimiento.ToString("yyyy-MM-dd");
                    if (((Usuario)Session["usuario"]).ImagenPerfil != null)
                        imgPerfil.ImageUrl = "~/images/" + ((Usuario)Session["usuario"]).ImagenPerfil;
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                string ruta = Server.MapPath("./images/");
                Usuario usuario = (Usuario)Session["usuario"];
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                if (txtImagen.PostedFile.FileName != "")
                {
                    usuario.ImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                }
                else
                    usuario.ImagenPerfil = null;
                usuario.User = txtNombreUsuario.Text;
                usuario.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                if (DateTime.Parse(txtFechaNacimiento.Text) < DateTime.Parse("1900 / 01 / 01"))
                {
                    lblNacimiento.Text = "La fecha debe ser mayor al 01/01/1900";
                    return;
                }
                else if (DateTime.Parse(txtFechaNacimiento.Text) > DateTime.Parse("2079 / 06 / 06"))
                {
                    lblNacimiento.Text = "La fecha debe ser menor al 06/06/2079";
                    return;
                }
                negocio.actualizar(usuario);
                Response.Redirect("default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}