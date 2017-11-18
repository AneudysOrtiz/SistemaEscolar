using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEscolar.Models
{
    public class Admission
    {

        public int AdmissionId { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string ActaNacimiento { get; set; }

        public string RecordNotas { get; set; }

        public string Foto { get; set; }

        public string BuenaConducta { get; set; }

        public string CartaSaldo { get; set; }

        public int Status { get; set; }
    }
}