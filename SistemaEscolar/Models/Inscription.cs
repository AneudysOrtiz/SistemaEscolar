using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEscolar.Models
{
    public class Inscription
    {
        public int InscriptionId { get; set; }

        public int StudentId { get; set; }

        public DateTime Date { get; set; }
    }
}