using PrepareSubmittalTool.Extensions.TeklaExtensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;


namespace PrepareSubmittalTool.Model
{
    public static class TemporaryFields
    {
        public static Dictionary<string, List<DrawingAndRevisionInfo>> SelectedDrawingAndRevisionInfos = new Dictionary<string, List<DrawingAndRevisionInfo>>()
        {
            {"PART",new List<DrawingAndRevisionInfo>() },
            {"SHOP", new List<DrawingAndRevisionInfo>()},
            {"E-PLANS", new List<DrawingAndRevisionInfo>()}
        };

        public static Dictionary<string, List<ElementInfo>> SelectedElementsInfo = new Dictionary<string, List<ElementInfo>>()
        {
            {"MAINPART",new List<ElementInfo>()},
            {"SECONDARYPART", new List<ElementInfo>()}
        };

        public static void readSelectedDrawigs()
        {
            ReadInformationFromSelectedDrawings readInformation = new ReadInformationFromSelectedDrawings();
            readInformation.ReadDrawings();
        }

        public static void readSelectedElements()
        {
            ReadInformationFromSelectedElements readInformation = new ReadInformationFromSelectedElements();
            readInformation.ReadSelectedElements();
        }



    }
}
