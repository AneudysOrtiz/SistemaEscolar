using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaEscolar.Models
{
    public class GeneralContext:DbContext
    {
        public GeneralContext():base("MyDB")
        {

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Inscription> Inscriptions { get; set; }

        public DbSet<Admission> Admissions { get; set; }
    }
}