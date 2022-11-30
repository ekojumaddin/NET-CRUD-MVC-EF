using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDMVCEF.Models
{
    public class ModelEntities : DbContext
    {
        public ModelEntities()
            : base("ModelEntities")
        {
            Database.SetInitializer<ModelEntities>(null);
        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }


    }
}