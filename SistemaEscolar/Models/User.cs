using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaEscolar.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(30)]
        
        public string Name { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        public string Picture { get; set; }

        public string Email { get; set; }

        [StringLength(30)]
        public string Sexo { get; set; }

        [StringLength(30)]
        [Phone]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        [Required]
        public string Rol { get; set; }
    }
}