using ControlzEx.Standard;
using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Drawing;
using Tekla.Structures;
using System.Runtime.InteropServices;
using Tekla.Structures.Model;
using Tekla.Structures.DrawingInternal;
using System.Runtime.CompilerServices;
using System.Reflection;
using Newtonsoft.Json.Linq;
using static Tekla.Structures.Model.RebarSpacing.ExactSpacing;

namespace PrepareSubmittalTool.Extensions.TeklaExtensions
{
    public class ReadInformationFromSelectedDrawings
    {
        public void ReadDrawings()
        {
            var drawingsInfo = new Dictionary<string, List<DrawingAndRevisionInfo>>()
            {
                {"PART",new List<DrawingAndRevisionInfo>() },
                {"SHOP", new List<DrawingAndRevisionInfo>()},
                {"E-PLANS", new List<DrawingAndRevisionInfo>()}
            };
            var dh = new Tekla.Structures.Drawing.DrawingHandler();
            var selector = dh.GetDrawingSelector();
            var drawingsSelector = selector.GetSelected();
            
            while(drawingsSelector.MoveNext())
            {
                
                if (drawingsSelector.Current is SinglePartDrawing)
                {
                    var element = GetInfoAboutRevision(drawingsSelector.Current);
                    drawingsInfo["PART"].Add(element);
                }
                if (drawingsSelector.Current is AssemblyDrawing)
                {
                    var element = GetInfoAboutRevision(drawingsSelector.Current);
                    drawingsInfo["SHOP"].Add(element);
                }
                if(drawingsSelector.Current is GADrawing) 
                {
                    var element = GetInfoAboutRevision(drawingsSelector.Current);
                    drawingsInfo["E-PLANS"].Add(element);
                }
            }
        }

        private DrawingAndRevisionInfo GetInfoAboutRevision(Drawing drawing)
        {
            Type type = drawing.GetType();
            PropertyInfo propertyInfo = type.GetProperty("Identifier", BindingFlags.Instance | BindingFlags.NonPublic);
            object val = propertyInfo.GetValue(drawing, null);
            Identifier identifier = (Identifier)val;
            Beam fakeBeam = new Beam { Identifier = identifier };
            string rev = string.Empty;
            string descrition = string.Empty;
            fakeBeam.GetReportProperty("REVISION.LAST_MARK", ref rev);
            fakeBeam.GetReportProperty("REVISION.DESCRIPTION", ref descrition);
            DrawingAndRevisionInfo drawingInfo = new DrawingAndRevisionInfo();
            if (drawing.GetType().Name == "GADrawing")
                drawingInfo.DrawingNumber = drawing.Name;
            else
                drawingInfo.DrawingNumber = drawing.Mark;
            drawingInfo.RevisionNumber = rev;
            drawingInfo.Description = descrition;

            return drawingInfo;
        }
    }
}
