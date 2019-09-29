using CalcMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalcMVC.Models.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=.;Database=CALC_DB;Trusted_Connection=true";
        }

        public DbSet<User> Users { get; set; }
    }
}