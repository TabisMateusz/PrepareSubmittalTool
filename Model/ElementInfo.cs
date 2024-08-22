using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareSubmittalTool.Model
{
    public class ElementInfo
    {
        public string PartNumber { get; set; }
        public int MainPart { get; set; }
        public bool IsNumbering { get; set; }
        public int Phase { get; set; }
    }
}
