using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebAPIjQuerAjax.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("name=AppDbContext")
        {
                
        }
        public virtual DbSet<Person> Persons { get; set; }
    }
}