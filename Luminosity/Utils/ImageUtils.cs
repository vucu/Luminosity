using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Luminosity.Utils
{
    public class ImageUtils
    {
        public static double CalculateLuminance(double r, double g, double b)
        {
            var y = 0.2126 * r + 0.7152 * g + 0.0722 * b;
            return y;
        }

        public static void LuminanceBlend(WriteableBitmap source)
        {
            int width = source.PixelWidth;
            int height = source.PixelHeight;
            int stride = source.BackBufferStride;
            int bytesPerPixel = (source.Format.BitsPerPixel + 7) / 8;

            source.Lock();


        }
    }
}
