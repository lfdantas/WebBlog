using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebBlog.Models
{
    public class Autor
    {
        public int AutorId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Formacao { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}