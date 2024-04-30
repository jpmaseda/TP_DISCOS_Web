using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }
        public string UrlImagenTapa { get; set; }
        [DisplayName("Cantidad de canciones")]
        public int CantidadCanciones { get; set; }
        [DisplayName("Año de lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }
        public Estilo Estilo { get; set; }
        [DisplayName("Edición")]
        public Edicion Edicion { get; set; }

    }
}
