using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Luminosity.Utils
{
    public static class ImageUtils
    {
        public static double CalculateLuminance(double rNorm, double gNorm, double bNorm)
        {
            var y = 0.2126 * rNorm + 0.7152 * gNorm + 0.0722 * bNorm;
            return y;
        }

        public static Color LuminanceBlend(this Color source)
        {
            var rNorm = (double)source.R / 255;
            var gNorm = (double)source.G / 255;
            var bNorm = (double)source.B / 255;
            var yNorm = CalculateLuminance(rNorm, gNorm, bNorm);
            var lightness = Convert.ToByte((uint)Math.Round(yNorm * 255));
            var r = lightness;
            var g = lightness;
            var b = lightness;
            return Color.FromRgb(r, g, b);
        }

        public static void LuminanceBlend(this WriteableBitmap source)
        {
            source.ForEach((x, y, c) => c.LuminanceBlend());
        }
    }
}
