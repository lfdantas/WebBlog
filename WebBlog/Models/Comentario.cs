using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBlog.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public int PostId { get; set; }
        public DateTime dataComentario { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        [Column("Comentario", TypeName="ntext")]
        [DataType(DataType.MultilineText)]
        public string comenatrio { get; set; }
        public virtual Post Post { get; set; }
    }
}
