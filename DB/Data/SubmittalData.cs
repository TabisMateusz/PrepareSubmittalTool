using PrepareSubmittalTool.DB.Context;
using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareSubmittalTool.DB.Data
{
    public static class SubmittalData
    {
        public static void AddSubmittal(Submittal submittal)
        {
            using (var db = new SubmittalContext())
            {
                db.Add(submittal);
                db.SaveChanges();
            }
        }
    }
}
