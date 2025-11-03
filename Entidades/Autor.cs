using System.ComponentModel.DataAnnotations;

namespace WebApi.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        public required string Nombre { get; set; }
    }
}