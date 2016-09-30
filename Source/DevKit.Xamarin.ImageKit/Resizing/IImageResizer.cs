using System.Threading.Tasks;

namespace DevKit.Xamarin.ImageKit.Abstractions
{
    public interface IImageResizer
    {
        /// <summary>
        /// Scales an image.
        /// </summary>
        /// <returns>The scaled image.</returns>
        /// <param name="originalImage">Original image.</param>
        /// <param name="finalImagePercentage">Final image percentage.</param>
        /// <param name="imageFormat">Image format Jpg or Png.</param>
        Task<byte[]> ScaleImage(byte[] originalImage, double finalImagePercentage, ImageFormat imageFormat);

        /// <summary>
        /// Resizes an image.
        /// </summary>
        /// <returns>The resized image.</returns>
        /// <param name="originalImage">Original image.</param>
        /// <param name="newHeight">New height.</param>
        /// <param name="newWidth">New width.</param>
        /// <param name="imageFormat">Image format Jpg or Png.</param>
        Task<byte[]> ResizeImage(byte[] originalImage, int newHeight, int newWidth, ImageFormat imageFormat);

        /// <summary>
        /// Reduces the quality of a Jpg image.
        /// </summary>
        /// <returns>The low quality image.</returns>
        /// <param name="originalImage">Original image.</param>
        /// <param name="newQuality">New quality from 1 to 100.</param>
        Task<byte[]> ReduceJPGQuality(byte[] originalImage, int newQuality);
    }
}