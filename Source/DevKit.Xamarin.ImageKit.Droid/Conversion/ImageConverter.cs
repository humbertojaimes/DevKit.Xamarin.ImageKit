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
        public async Task<byte[]> ConvertJpgToPngAsync(byte[] image)
        {
            byte[] resultByteArray = null;
            Bitmap bitmap = await image.ToBitmapAsync();
            resultByteArray = await bitmap.ToByteArrayAsync(Abstractions.ImageFormat.PNG);
            return resultByteArray;
        }

        /// <summary>
        /// Converts the png image to jpg image.
        /// </summary>
        /// <returns>The jpg image.</returns>
        /// <param name="image">The original image.</param>
        public async Task<byte[]> ConvertPngToJpgAsync(byte[] image, int quality)
        {
            byte[] resultByteArray = null;
            Bitmap bitmap = await image.ToBitmapAsync();
            resultByteArray = await bitmap.ToByteArrayAsync(Abstractions.ImageFormat.JPG, quality);
            return resultByteArray;
        }
    }
}