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
        Task<byte[]> ConvertJpgToPngAsync(byte[] image);

        /// <summary>
        /// Converts the png image to jpg image.
        /// </summary>
        /// <returns>The jpg image.</returns>
        /// <param name="image">The original image.</param>
        Task<byte[]> ConvertPngToJpgAsync(byte[] image, int quality);
    }
}