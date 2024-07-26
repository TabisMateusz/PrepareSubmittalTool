using PrepareSubmittalTool.Extensions.TeklaExtensions;
using System.Collections.ObjectModel;


namespace PrepareSubmittalTool.Model
{
    public static class TemporaryFields
    {
        public static ObservableCollection<DrawingAndRevisionInfo> ShopDrawingAndRevisionInfos = new ObservableCollection<DrawingAndRevisionInfo>();
        public static void readSelectedDrawigs()
        {
            ReadInformationFromSelectedDrawings readInformation = new ReadInformationFromSelectedDrawings();

            readInformation.ReadDrawings();
            
        }
    }
}
