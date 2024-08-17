using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace PrepareSubmittalTool.Extensions.TeklaExtensions
{
    public class GetInfoAboutModel
    {
        private readonly Tekla.Structures.Model.Model currentModel = new Tekla.Structures.Model.Model();

        public readonly string Data = DateTime.Now.ToString("MMM_dd_yy", (IFormatProvider)new CultureInfo("en-us")).ToUpper();
        public string GetModelName()
        {
            return currentModel.GetInfo().ModelName.Replace(".db1", "");
        }

        //public string GetSubmittalName()
        //{
        //    string companyName = string.Empty;
        //    ProjectInfo projectInfo = currentModel.GetProjectInfo();
        //    projectInfo.GetUserProperty("TR_COMPANY", ref companyName);

        //    return submittalNumber.ToString();
        //}
    }
}
