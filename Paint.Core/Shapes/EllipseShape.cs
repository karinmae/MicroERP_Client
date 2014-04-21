using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Core.Shapes
{
    class EllipseShape : ICloneable
    {
        double radiusX;
        double radiusY;
       
        public double RadiusX
        {
            get { return radiusX; }
            set { radiusX = value; }
        }

        public double RadiusY
        {
            get { return radiusY; }
            set { radiusY = value; }
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

