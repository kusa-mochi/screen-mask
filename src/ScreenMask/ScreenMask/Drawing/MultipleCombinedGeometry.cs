using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ScreenMask.Drawing
{
    public class CombinedGeometryGenerator
    {
        public static Geometry Add(List<Geometry> geometries)
        {
            if (geometries == null)
            {
                throw new ArgumentNullException("geometries");
            }
            if (geometries.Count == 0)
            {
                throw new ArgumentException();
            }

            Geometry output = Combine(geometries, GeometryCombineMode.Union);

            return output;
        }

        public static Geometry Subtract(List<Geometry> geometries)
        {
            if (geometries == null)
            {
                throw new ArgumentNullException("geometries");
            }
            if (geometries.Count == 0)
            {
                throw new ArgumentException();
            }

            Geometry output = Combine(geometries, GeometryCombineMode.Exclude);

            return output;
        }

        private static Geometry Combine(List<Geometry> geometries, GeometryCombineMode combineMode)
        {
            Geometry output = geometries[0];
            for (int i = 1; i < geometries.Count; i++)
            {
                output = Geometry.Combine(output, geometries[i], combineMode, null);
            }

            return output;
        }
    }
}
