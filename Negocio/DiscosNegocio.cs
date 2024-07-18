using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DiscosNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        public List<Disco> listarActivos()
        {
            //SqlConnection conexion = new SqlConnection();
            //SqlCommand comando = new SqlCommand();
            //SqlDataReader lector;

            List<Disco> lista = new List<Disco>();

            try
            {
                //conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                //comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "Select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, T.Descripcion TipoEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo AND T.Id = D.IdTipoEdicion";
                //comando.Connection = conexion;
                //conexion.Open();
                //lector = comando.ExecuteReader();

                datos.setearConsulta("Select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, T.Descripcion TipoEdicion, E.Id IdEstilo, T.Id IdEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo AND T.Id = D.IdTipoEdicion AND D.Activo = 1");
                datos.ejecutarLectura();

                //while (lector.Read())
                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = datos.Lector.GetDateTime(1);
                    aux.CantidadCanciones = datos.Lector.GetInt32(2);
                    //if (datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagenTapa")))
                    //    aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Id = (int)datos.Lector["IdEdicion"];
                    aux.Edicion.Descripcion = (string)datos.Lector["TipoEdicion"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];

                    lista.Add(aux);
                }
                // conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void agregar(Disco disco)
        {
            try
            {
                datos.setearConsulta("Insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion, Activo)values('" + disco.Titulo + "', @FechaLanzamiento, " + disco.CantidadCanciones + ", '" + disco.UrlImagenTapa + "', @IdEstilo, @IdTipoEdicion, 1)");
                datos.setearParametro("@FechaLanzamiento", disco.FechaLanzamiento);
                datos.setearParametro("@IdEstilo", disco.Estilo.Id);
                datos.setearParametro("@IdTipoEdicion", disco.Edicion.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregarSP(Disco disco)
        {
            try
            {
                datos.setearProcedimiento("altaDisco");
                datos.setearParametro("@titulo", disco.Titulo);
                datos.setearParametro("@fechalanzamiento", disco.FechaLanzamiento);
                datos.setearParametro("@cantidadcanciones", disco.CantidadCanciones);
                datos.setearParametro("@urlimagentapa", disco.UrlImagenTapa);
                datos.setearParametro("@idestilo", disco.Estilo.Id);
                datos.setearParametro("@idtipoedicion", disco.Edicion.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Disco disco)
        {            
            try
            {
                datos.setearConsulta("Update DISCOS set Titulo = @Titulo, FechaLanzamiento = @Año, CantidadCanciones = @Canciones, UrlImagenTapa = @UrlTapa, IdEstilo = @Estilo, IdTipoEdicion = @Edicion where Id = @Id");
                datos.setearParametro("@Titulo", disco.Titulo);
                datos.setearParametro("@Año", disco.FechaLanzamiento);
                datos.setearParametro("@Canciones", disco.CantidadCanciones);
                datos.setearParametro("@UrlTapa", disco.UrlImagenTapa);
                datos.setearParametro("@Estilo", disco.Estilo.Id);
                datos.setearParametro("@Edicion", disco.Edicion.Id);
                datos.setearParametro("@Id", disco.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificarSP(Disco disco)
        {
            try
            {
                datos.setearProcedimiento("modificarDisco");
                datos.setearParametro("@Titulo", disco.Titulo);
                datos.setearParametro("@Año", disco.FechaLanzamiento);
                datos.setearParametro("@Canciones", disco.CantidadCanciones);
                datos.setearParametro("@UrlTapa", disco.UrlImagenTapa);
                datos.setearParametro("@Estilo", disco.Estilo.Id);
                datos.setearParametro("@Edicion", disco.Edicion.Id);
                datos.setearParametro("@Id", disco.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            try
            {
                datos.setearConsulta("Delete from DISCOS where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminarSP(int id)
        {
            try
            {
                datos.setearProcedimiento("eliminarFisico");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminarLogico(int id, bool activo = false)
        {
            try
            {
                datos.setearConsulta("update DISCOS set Activo = @activo where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
       
        public List<Disco> filtrar(string campo, string criterio, string filtro, string activo)
        {
            string consulta = "Select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, T.Descripcion TipoEdicion, E.Id IdEstilo, T.Id IdEdicion, D.Id, D.Activo from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo AND T.Id = D.IdTipoEdicion ";
            List<Disco> lista = new List<Disco>();
            try
            {
                if (filtro != "")
                {
                    if (campo == "Año de lanzamiento")
                    {
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "AND FechaLanzamiento > '" + filtro + "'";
                                break;
                            case "Menor a":
                                consulta += "AND FechaLanzamiento < '" + filtro + "1231'";
                                break;
                            default:
                                consulta += "AND FechaLanzamiento <= '" + filtro + "1231' AND FechaLanzamiento >= '" + filtro + "0101'";
                                break;                            
                        }
                    }
                    else if (campo == "Título")
                    {
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "AND Titulo like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "AND Titulo like '%" + filtro + "'";
                                break;                                
                            default:
                                consulta += "AND Titulo like '%" + filtro + "%'";
                                break;
                        }
                    }
                }
                if (campo == "Estilo")
                {
                    consulta += "AND E.Descripcion = '" + criterio + "'";
                }
                if (activo == "Activo")
                    consulta += "AND D.Activo = 1";
                else if (activo == "Inactivo")
                    consulta += "AND D.Activo = 0";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = datos.Lector.GetDateTime(1);
                    aux.CantidadCanciones = datos.Lector.GetInt32(2);                    
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Id = (int)datos.Lector["IdEdicion"];
                    aux.Edicion.Descripcion = (string)datos.Lector["TipoEdicion"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());
                    lista.Add(aux);
                }                
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }        
        }
        
        public List<Disco> listarSP()
        {
            List<Disco> lista = new List<Disco>();

            try
            {
                datos.setearProcedimiento("listar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = datos.Lector.GetDateTime(1);
                    aux.CantidadCanciones = datos.Lector.GetInt32(2);
                  
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Id = (int)datos.Lector["IdEdicion"];
                    aux.Edicion.Descripcion = (string)datos.Lector["TipoEdicion"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
