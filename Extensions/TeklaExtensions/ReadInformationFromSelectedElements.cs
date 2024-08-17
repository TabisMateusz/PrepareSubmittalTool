using PrepareSubmittalTool.Model;
using Tekla.Structures.Model;

namespace PrepareSubmittalTool.Extensions.TeklaExtensions
{
    public class ReadInformationFromSelectedElements
    {
        public void ReadSelectedElements()
        {
            Tekla.Structures.Model.ModelObjectEnumerator moe = new Tekla.Structures.Model.UI.ModelObjectSelector().GetSelectedObjects();
            TemporaryFields.SelectedElementsInfo["MAINPART"].Clear();
            TemporaryFields.SelectedElementsInfo["SECONDARYPART"].Clear();

            
            while (moe.MoveNext()) 
            { 
                if (moe.Current is Tekla.Structures.Model.Part myPart)
                {
                    string partNumber = string.Empty;
                    int mainPart = 0;
                    myPart.GetReportProperty("MAIN_PART", ref mainPart);
                    myPart.GetReportProperty("PART_POS", ref partNumber);
                    bool isNumber = Tekla.Structures.Model.Operations.Operation.IsNumberingUpToDate(myPart);

                    if (mainPart == 1)
                    {
                        TemporaryFields.SelectedElementsInfo["MAINPART"].Add(
                            new ElementInfo
                            {
                                PartNumber = partNumber,
                                MainPart = mainPart,
                                IsNumbering = isNumber,
                            });
                    }
                    else
                    {
                        TemporaryFields.SelectedElementsInfo["SECONDARYPART"].Add(
                            new ElementInfo
                            {
                                PartNumber = partNumber,
                                MainPart = mainPart,
                                IsNumbering = isNumber,
                            });
                    }
                    
                }
            }
        }
    }
}
