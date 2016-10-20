using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Democracy.Models
{

    //para conectarse a la base de datos
    public class DemocratyContext: DbContext
    {

       public DemocratyContext() : base("DefaultConnection") //nombre de la cadena de conexion
        {

        }
        //se van agregando las propiedades (Dbset) a medida que se quiere enviar datos a determindaas tablas de base de datos
        public DbSet<State> States { get; set; }
    }
}