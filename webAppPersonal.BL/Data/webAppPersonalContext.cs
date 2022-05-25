using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAppPersonal.BL.Models;

namespace webAppPersonal.BL.Data
{
    public class webAppPersonalContext: DbContext
    {
        private static webAppPersonalContext webappPersonalContext = null;
        public webAppPersonalContext()
            : base("webAppPersonalContext")
        {
        
        }

        // Mapeo
        public DbSet<persona> Personas { get; set; }
        public DbSet<producto> Productos { get; set; }

        // Patron de Singleton (unica instancia)
        public static webAppPersonalContext Create() {
            if (webappPersonalContext == null) {
                webappPersonalContext = new webAppPersonalContext();
                return webappPersonalContext;
            }
            return new webAppPersonalContext(); 
        }
    }
}
