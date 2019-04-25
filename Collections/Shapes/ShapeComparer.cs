using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Shapes
{
    internal class ShapeComparer : IEqualityComparer<Shape>
    {
        public bool Equals(Shape firstShape, Shape secondShape)
        {
            if (firstShape == null || secondShape == null)
            {
                return false;
            }

            if (firstShape == null && secondShape == null)
            {
                return true;
            }

            return CheckForEquality(firstShape, secondShape);
        }

        private bool CheckIfParallel(Shape first, Shape second)
        {

            int diffX = first.Points[0].X - second.Points[0].X;
            int diffY = first.Points[0].Y - second.Points[0].Y;

            for (int i = 1; i < first.Points.Count; i++)
            {
                int currDiffX = first.Points[i].X - second.Points[i].X;
                int currDiffY = first.Points[i].Y - second.Points[i].Y;
                if (!(currDiffX == diffX && currDiffY == diffY))
                {
                    return false;
                }

            }

            return true;
        }

        private bool CheckForEquality(Shape first, Shape second)
        {
            if (this.CheckIfParallel(first, second))
            {
                return true;
            }

            var rotatedShape = GetRotatedShape(second, 90);
            if (this.CheckIfParallel(first, rotatedShape))
            {
                return true;
            }

            rotatedShape = GetRotatedShape(rotatedShape, 90);
            if (this.CheckIfParallel(first, rotatedShape))
            {
                return true;
            }

            rotatedShape = GetRotatedShape(rotatedShape, 90);
            if (this.CheckIfParallel(first, rotatedShape))
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(Shape obj)
        {
            return obj.Points.Count.GetHashCode();
        }

        private Shape GetRotatedShape(Shape shape, double angle)
        {
            Point[] rotatedPoints = new Point[shape.Points.Count];
            for (int i = 0; i < rotatedPoints.Length; i++)
            {
                rotatedPoints[i] = GetRotatedPoint(90, shape.Points[i]);
            }

            return new Shape(rotatedPoints);
        }

        private Point GetRotatedPoint(double angle, Point pt)
        {
            int newX = (-pt.Y);
            int newY = (pt.X);
            return new Point(newX, newY);
        }
    }
}
