using System;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace QuickPeek
{
    internal static class Utilities
    {
        public static string ToProperString(this Color color)
        {
            var colorProperties = typeof(Color)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(Color));

            foreach (var prop in colorProperties)
            {
                var predefinedColor = (Color)prop.GetValue(null);

                if (color.ToArgb() == predefinedColor.ToArgb())
                    return prop.Name;
            }

            return $"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}";
        }

        private static double GetColorDistance(Color c1, Color c2)
        {
            double rDiff = c1.R - c2.R;
            double gDiff = c1.G - c2.G;
            double bDiff = c1.B - c2.B;
            return Math.Sqrt(rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);
        }
    }
}
