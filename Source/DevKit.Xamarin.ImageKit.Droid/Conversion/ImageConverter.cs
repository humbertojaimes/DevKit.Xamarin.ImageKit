using Android.Graphics;
using DevKit.Xamarin.ImageKit.Abstractions;
using DevKit.Xamarin.ImageKit.Droid.Utils;
using System.Threading.Tasks;

namespace DevKit.Xamarin.ImageKit
{
    public class ImageConverter : IImageConverter
    {
        /// <summary>
        /// Converts the jpg image to png image.
        /// </summary>
        /// <returns>The png image.</returns>
        /// <param name="image">The original image.</param>
        public byte[] ConvertJpgToPng(byte[] image)
        {
            byte[] resultByteArray = null;
            Bitmap bitmap = image.ToBitmap();
            resultByteArray = bitmap.ToByteArray(Abstractions.ImageFormat.PNG);
            bitmap.Dispose();
            return resultByteArray;
        }

        /// <summary>
        /// Converts the png image to jpg image.
        /// </summary>
        /// <returns>The jpg image.</returns>
        /// <param name="image">The original image.</param>
        public byte[] ConvertPngToJpg(byte[] image, int quality)
        {
            byte[] resultByteArray = null;
            Bitmap bitmap = image.ToBitmap();
            resultByteArray = bitmap.ToByteArray(Abstractions.ImageFormat.JPG, quality);
            bitmap.Dispose();
            return resultByteArray;
        }
    }
}