using DevKit.Xamarin.ImageKit.Abstractions;
using DevKit.Xamarin.ImageKit.iOS.Utils;
using System;
using System.Threading.Tasks;
using UIKit;

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
            UIImage uiImage = await image.ToImageAsync();
            return uiImage.AsPNG().ToArray();
        }

        /// <summary>
        /// Converts the png image to jpg image.
        /// </summary>
        /// <returns>The jpg image.</returns>
        /// <param name="image">The original image.</param>
        public async Task<byte[]> ConvertPngToJpgAsync(byte[] image, int quality)
        {
            UIImage uiImage = await image.ToImageAsync();
            nfloat fQuality = quality / 100;
            return uiImage.AsJPEG(fQuality).ToArray();
        }
    }
}