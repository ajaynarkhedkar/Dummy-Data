using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CodeFirstEntityFramework.Models;

namespace CodeFirstEntityFramework.Context
{
    public class clsContext : DbContext
    {
        public DbSet<Students> tblStudents {  get; set; }
    }
}