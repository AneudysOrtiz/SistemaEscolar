using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaEscolar.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        public string RolName {get; set;}

        public string RolCode { get; set; }

    }
}