using Microsoft.EntityFrameworkCore;
using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareSubmittalTool.DB.Context
{
    public class SubmittalContext : DbContext
    {
        public DbSet<Submittal> SUBMITTAL { get; set; }

        private string path = "D:\\AUTOZAPIS\\PROJECTS2.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source ={path}");
        }
    }
}
