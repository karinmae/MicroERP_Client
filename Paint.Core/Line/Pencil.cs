using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Paint.Core.Line
{
    class Pencil : ICloneable
    {
        Point posX;
        Point posY;

        public Point PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public Point PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        private object DeepCopy()
        {
            Pencil cloned = this.MemberwiseClone() as Pencil;
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
