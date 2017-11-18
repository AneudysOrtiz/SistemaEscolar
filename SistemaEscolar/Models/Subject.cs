using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEscolar.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string Name { get; set; }

        public int TeacherId { get; set; }

        public string Description { get; set; }

        public string Schedule { get; set; }

        public int Stock { get; set; }
    }
}