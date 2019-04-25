using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Shapes
{
    internal class PointComparer : IComparer<Point>
    {
        public int Compare(Point a, Point b)
        {
            if ((a.X == b.X) && (a.Y == b.Y))
                return 0;
            if ((a.X < b.X) || ((a.X == b.X) && (a.Y < b.Y)))
                return -1;

            return 1;
        }
    }
}
