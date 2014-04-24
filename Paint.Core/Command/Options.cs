using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Core.Command
{
    class Options
    {
        public enum op
        {

            newShape_regtangle, newShape_ellipse, newLine_Pencil, newLine_Marker, moveShape, groupShape, resize
        };
        public op type { get; set; }

    }
}
