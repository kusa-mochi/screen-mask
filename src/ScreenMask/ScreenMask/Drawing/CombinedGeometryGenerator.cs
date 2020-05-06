using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ScreenMask.Drawing
{
    public class CombinedGeometryGenerator
    {
        public static Geometry Add(Geometry origin, List<Geometry> geometries)
        {
            if (origin == null)
            {
                throw new ArgumentNullException("origin");
            }
            if (geometries == null || geometries.Count == 0)
            {
                return origin;
            }

            Geometry output = Combine(origin, geometries, GeometryCombineMode.Union);

            return output;
        }

        public static Geometry Subtract(Geometry origin, List<Geometry> geometries)
        {
            if (origin == null)
            {
                throw new ArgumentNullException("origin");
            }
            if (geometries == null || geometries.Count == 0)
            {
                return origin;
            }

            Geometry output = Combine(origin, geometries, GeometryCombineMode.Exclude);

            return output;
        }

        private static Geometry Combine(Geometry origin, List<Geometry> geometries, GeometryCombineMode combineMode)
        {
            Geometry output = origin;
            foreach (Geometry g in geometries)
            {
                output = Geometry.Combine(output, g, combineMode, null);
            }

            return output;
        }
    }
}
