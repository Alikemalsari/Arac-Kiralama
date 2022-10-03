using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AracKiralama.Models
{
    public class Context:DbContext
    {
       public DbSet<Login> Logins { get; set; }
       public DbSet<AracBilgileri> AracBilgileris { get; set; }
       public DbSet<Kiralayan> Kiralayans { get; set; }
    }
}