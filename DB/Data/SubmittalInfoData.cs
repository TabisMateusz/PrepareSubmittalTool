using PrepareSubmittalTool.DB.Context;
using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareSubmittalTool.DB.Data
{
    public static class SubmittalInfoData
    {
        public static void AddSubmittalInfo(SubmittalInfo submittalInfo)
        {
            using (var context = new DataBaseContext())
            {
                context.Add(submittalInfo);
                context.SaveChangesAsync();
            }
        }
    }
}
