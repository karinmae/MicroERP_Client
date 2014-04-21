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
            newShape, moveShape, groupShape
        };
        public op type { get; set; }

    }
}
