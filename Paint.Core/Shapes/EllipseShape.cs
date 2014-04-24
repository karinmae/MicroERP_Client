using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Core.Shapes
{
    class EllipseShape : ICloneable
    {
        double height;
        double width;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        private object DeepCopy()
        {
            EllipseShape cloned = this.MemberwiseClone() as EllipseShape;
            return cloned;
        }

        #region ICloneable Members

        public object Clone()
        {
            return DeepCopy();
        }

        #endregion
    }
}

