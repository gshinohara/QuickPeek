using Rhino.DocObjects;
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

        public static string GetBlockType(this InstanceDefinition instanceDefinition)
        {
            switch (instanceDefinition.UpdateType)
            {
                case InstanceDefinitionUpdateType.Static:
                case InstanceDefinitionUpdateType.Embedded:
                    return "Embeded";
                case InstanceDefinitionUpdateType.LinkedAndEmbedded:
                    return "Linked and Embeded";
                case InstanceDefinitionUpdateType.Linked:
                    return "Linked";
                default:
                    return "Undefined";
            }
        }
    }
}
