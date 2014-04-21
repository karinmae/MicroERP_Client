using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Core.Shapes
{
    class RectangleShape : ICloneable
    {
        double height;
        double width;
        //AdditionalDetails m_details = new AdditionalDetails();

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

        /*public AdditionalDetails Details
        {
            get { return m_details; }
            set { m_details = value; }
        }*/

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        private object DeepCopy()
        {
            RectangleShape cloned = this.MemberwiseClone() as RectangleShape;
            //cloned.Details = new AdditionalDetails();
            //cloned.Details.Charisma = this.Details.Charisma;
            //cloned.Details.Fitness = this.Details.Fitness;

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

