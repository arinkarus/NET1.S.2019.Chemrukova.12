using Collections.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    /// <summary>
    /// Finds shapes.
    /// </summary>
    public static class ShapesFinding
    {
        /// <summary>
        /// Find shapes on the map.
        /// </summary>
        /// <param name="map">Given map.</param>
        /// <returns>Get unique shapes on the map.</returns>
        public static IEnumerable<Shape> GetShapes(int[][] map)
        {
            ValidateMap(map);
            var uniqueShapes = new HashSet<Shape>(new ShapeComparer());
            BitArray[] visited = new BitArray[map.Length];
            for (int i = 0; i < map.Length; i++)
            {
                visited[i] = new BitArray(map[0].Length, false);
            }

            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    if (map[i][j] != 0 && !visited[i][j])
                    {
                        var points = new List<Point>();
                        FindPointsForShape(map, visited, i, j, points);
                        uniqueShapes.Add(new Shape(points));
                    }
                }
            }

            return uniqueShapes;
        }

        /// <summary>
        /// Validates if passed map is correct.
        /// </summary>
        /// <param name="map">Given map.</param>
        private static void ValidateMap(int[][] map)
        {
            if (map == null)
            {
                throw new ArgumentNullException($"Map is null {nameof(map)}");
            }

            if (map.Length == 0)
            {
                throw new ArgumentException($"Map is empty {nameof(map)}");
            }

            int columnCount = map[0].Length;
            for (int i = 1; i < map.Length; i++)
            {
                if (map[i].Length != columnCount)
                {
                    throw new ArgumentException($"Map has to has rectangular size! {nameof(map)}");
                }
            }
        }

        private static void FindPointsForShape(int[][] map, BitArray[] visited, int row, int col, List<Point> points)
        {
            if (row >= 0 && row < map.Length && col >= 0 && col < map[0].Length && map[row][col] != 0 && !visited[row][col])
            {
                points.Add(new Point(col, row));
                visited[row][col] = true;
                FindPointsForShape(map, visited, row, col + 1, points);
                FindPointsForShape(map, visited, row, col - 1, points);
                FindPointsForShape(map, visited, row - 1, col, points);
                FindPointsForShape(map, visited, row + 1, col, points);
            }
        }
    }
}
