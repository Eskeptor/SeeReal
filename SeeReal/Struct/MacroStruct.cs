using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeReal.Struct
{
    public class MacroStruct
    {
        public string MacroName { get; set; }

        public string Macro { get; set; }

        public bool Enable { get; set; }

        public MacroStruct Copy()
        {
            return (MacroStruct)MemberwiseClone();
        }
    }
}
