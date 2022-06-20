using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaTecnica.Entities
{
    [Table("Usuarios")]
    public class UsuarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public Int16 Id { get; set; }

        [Column("Nombre")]
        public string? Nombre { get; set; }

        [Column("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Column("Genero")]
        public string? Genero { get; set; }
    }
}