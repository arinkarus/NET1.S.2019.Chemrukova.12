using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Shapes
{
    /// <summary>
    /// Comparer for point.
    /// </summary>
    internal class PointComparer : IComparer<Point>
    {
        /// <summary>
        /// Compares two points.
        /// </summary>
        /// <param name="x">First point.</param>
        /// <param name="y">Second point.</param>
        /// <returns></returns>
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
