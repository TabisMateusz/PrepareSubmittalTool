using PrepareSubmittalTool.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TSM = Tekla.Structures.Model;

namespace PrepareSubmittalTool.Extensions.Tekla
{
    
    public class TeklaModelInfo
    {
        private readonly TSM.Model currentModel = new TSM.Model();

        public readonly string Data = DateTime.Now.ToString("MMM_dd_yy", (IFormatProvider)new CultureInfo("en-us")).ToUpper();
        public string GetModelName()
        {
            return currentModel.GetInfo().ModelName.Replace(".db1","");
        }

        public string GetSubmittalNumber()
        {
            int submittalNumber=0;
            string companyName = string.Empty;
            ProjectInfo projectInfo = currentModel.GetProjectInfo();
            projectInfo.GetUserProperty("TR_COMPANY", ref companyName);


            return submittalNumber.ToString();
        }
    }
}
