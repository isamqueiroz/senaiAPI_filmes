using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api_filmes_senai.Domains
{
    [Table("Genero")]
    public class Genero
    {

        [Key]
        public Guid IdGenero { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Nome do Genêro é obrigatório!")]
        public string? Nome{ get; set; }
    }
}
