using Collections.Shapes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Tests
{
    public class ShapeTests
    {
        private static IEnumerable<TestCaseData> TestCasesForShapes
        {
            get
            {
                yield return new TestCaseData(arg1: new int[][]
                                                   {new int[] {0, 0, 0, 0, 0 },
                                                    new int[] {0, 1, 0, 1, 0 },
                                                    new int[] {0, 1, 0, 1, 0 },
                                                    new int[] {0, 1, 0, 1, 0 },
                                                    new int[] {0, 0, 0, 0, 0 } },
                                                    arg2: new List<Shape>
                                                    {
                                                        new Shape(new List<Point>{ new Point(1, 1), new Point(1, 2), new Point(1, 3)}),
                                                    });

                yield return new TestCaseData(arg1: new int[][] {
                                                     new int[] { 0, 0, 1, 0, 0, 0, 1 },
                                                     new int[] { 0, 1, 1, 0, 0, 0, 1 },
                                                     new int[] { 0, 0, 0, 0, 1, 1, 0 },
                                                     new int[] { 0, 0, 0, 0, 0, 1, 0 },
                                                     new int[] { 1, 1, 0, 0, 0, 0, 0 }},
                                     arg2: new List<Shape>
                                     {
                                                         new Shape(new List<Point>() { new Point(1, 1), new Point(2, 0), new Point(2, 1)}),
                                                         new Shape(new List<Point> { new Point(6, 0), new Point(6, 1) })
                                     });

            }
        }

        [Test]
        public void GetShapes_NullMap_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ShapesFinding.GetShapes(null));

        [Test]
        public void GetShapes_EmptyMap_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => ShapesFinding.GetShapes(new int[][] { }));

        [Test]
        public void GetShapes_MapIsNotRectangular_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => ShapesFinding.GetShapes(new int[][] { new int[] { 1, 1 }, new int[] { 0, 0, 0 } }));

        [Test, TestCaseSource(nameof(TestCasesForShapes))]
        public void GetShapes_GivenMap_ReturnUniqueShapes(int[][] map, IEnumerable<Shape> expected)
        {
            Shape[] expectedShapes = expected.ToArray();
            Shape[] actualShapes = ShapesFinding.GetShapes(map).ToArray();
            CollectionAssert.AreEqual(expectedShapes, actualShapes);
        }
    }
}
