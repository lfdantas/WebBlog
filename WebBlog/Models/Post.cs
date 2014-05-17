using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBlog.Models
{
    [Table("Artigo")]
    public class Post
    {
        public Post()
        {
        }
        [Required]
        public int PostId { get; set; }
        [Required]
        public int AutorId { get; set; }
        [Required]
        [Column("Titulo")]
        public string Titulo { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Column("Conteudo", TypeName = "ntext")]
        public string Conteudo { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
