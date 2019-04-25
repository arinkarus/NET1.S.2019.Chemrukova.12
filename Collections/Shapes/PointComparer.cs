using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Shapes
{
    internal class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.Y != y.Y)
            {
                return x.Y - y.Y;
            }
            else
            {
                return x.X - y.X;
            }

        }
    }
}
