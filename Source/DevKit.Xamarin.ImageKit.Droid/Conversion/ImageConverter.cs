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
        public async Task<byte[]> ConvertJpgToPng(byte[] image)
        {
            byte[] resultByteArray = null;
            Bitmap bitmap = await image.ToBitmap();
            resultByteArray = await bitmap.ToByteArray(Abstractions.ImageFormat.PNG);
            return resultByteArray;
        }

        /// <summary>
        /// Converts the png image to jpg image.
        /// </summary>
        /// <returns>The jpg image.</returns>
        /// <param name="image">The original image.</param>
        public async Task<byte[]> ConvertPngToJpg(byte[] image, int quality)
        {
            byte[] resultByteArray = null;
            Bitmap bitmap = await image.ToBitmap();
            resultByteArray = await bitmap.ToByteArray(Abstractions.ImageFormat.JPG, quality);
            return resultByteArray;
        }
    }
}