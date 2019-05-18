using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Shapes
{
    /// <summary>
    /// Represents point.
    /// </summary>
    public struct Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        /// <summary>
        /// Gets or sets X coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets y coordinate.
        /// </summary>
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                return false;
            }

            var point = (Point)obj;
            return this.Equals(point);
        }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return (this.X, this.Y).GetHashCode();
        }
    }
}
