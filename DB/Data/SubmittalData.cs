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
            using (var context = new DataBaseContext())
            {
                context.Add(submittal);
                context.SaveChanges();
            }
        }

        public static bool AnySubmittalForProject(string projectName)
        {

            int projectId = ProjectData.GetProjectId(projectName);

            using (var context = new DataBaseContext())
            {
                return context.SUBMITTAL.Any(x => x.Project_ID == projectId);
            }
        }

        public static int GetLastSubmittalNumber(string projectName) 
        { 
            int projectId = ProjectData.GetProjectId(projectName);

            using (var context = new DataBaseContext())
            {
                return context.SUBMITTAL
                    .Where(x => x.Project_ID == projectId)
                    .OrderByDescending(x=>x.Submittal_ID)
                    .Select(x=>x.Submittal_Number)
                    .FirstOrDefault();
            }
        }
        public static int GetLastSubmittalId(string projectName)
        {
            int projectId = ProjectData.GetProjectId(projectName);

            using (var context = new DataBaseContext())
            {
                return context.SUBMITTAL
                    .Where(x => x.Project_ID == projectId)
                    .OrderByDescending(x => x.Submittal_ID)
                    .Select(x => x.Submittal_ID)
                    .FirstOrDefault();
            }

        }
    }
}
