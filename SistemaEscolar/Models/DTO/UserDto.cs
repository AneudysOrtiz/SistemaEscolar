using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEscolar.Models
{
    public class UserDto
    {

        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Picture { get; set; }

        public string Email { get; set; }

        public string Sexo { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Rol { get; set; }

        public string Url { get; set; }
    }
}