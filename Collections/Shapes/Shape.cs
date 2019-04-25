using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Shapes
{
    public class Shape: IEquatable<Shape>
    {
        private List<Point> points { get; set; }

        public List<Point> Points
        {
            get
            {
                var clone = new List<Point>(this.points);
                return clone;
            }
            private set
            {
                this.points = value ?? throw new ArgumentNullException($"Can't create shape without points!");
            }
        }

        public Shape(IEnumerable<Point> points)
        {
            List<Point> sorted = new List<Point>(points);
            sorted.Sort(new PointComparer());
            this.Points = sorted;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Shape other))
            {
                return false;
            }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Points.Count.GetHashCode();
        }

        public bool Equals(Shape other)
        {
            if (other.Points.Count != this.Points.Count)
            {
                return false;
            }

            for (int i = 0; i < this.Points.Count; i++)
            {
                if (!this.Points[i].Equals(other.Points[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
