using PrepareSubmittalTool.DB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareSubmittalTool.DB.Data
{
    public static class ProjectData
    {
        public static int GetProjectId(string projectName)
        {
            using (var context = new DataBaseContext())
            {
                return context.PROJECT.Where(x => x.Project_Name == projectName).Select(x => x.Project_ID).First();
            }
        }
    }
}
