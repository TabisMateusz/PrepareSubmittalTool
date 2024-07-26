using Microsoft.EntityFrameworkCore;
using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareSubmittalTool.DB.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Submittal> SUBMITTAL { get; set; }
        public DbSet<Client> CLIENT { get; set; }
        public DbSet<Project> PROJECT { get; set; }

        //private string path = "D:\\AUTOZAPIS\\!!!WAZNE!!!\\PROJECTS.db";
        private string path = "D:\\AUTOZAPIS\\!!!WAZNE!!!\\PROJECTS2.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source ={path}");
        }
    }
}
