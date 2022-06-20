using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models
{
    public class UsuarioModel
    {
        [Key]
        public Int16 Id { get; set; }

        public string? Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string? Genero { get; set; }
    }
}
