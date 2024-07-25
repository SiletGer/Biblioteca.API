using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Biblioteca.Entites.DTO
{
    internal class AutorDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener mas de 50 Caracteres.")]
        public string NombreAutor { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener mas de 50 Caracteres.")]

        public string ApellidoAutor {  get; set; } = string.Empty;
    }
}
