using System.Threading.Tasks;

namespace DevKit.Xamarin.ImageKit.Abstractions
{
    public interface IImageConverter
    {
        /// <summary>
        /// Converts the jpg image to png image.
        /// </summary>
        /// <returns>The png image.</returns>
        /// <param name="image">The original image.</param>
        byte[] ConvertJpgToPng(byte[] image);

        /// <summary>
        /// Converts the png image to jpg image.
        /// </summary>
        /// <returns>The jpg image.</returns>
        /// <param name="image">The original image.</param>
        byte[] ConvertPngToJpg(byte[] image, int quality);
    }
}