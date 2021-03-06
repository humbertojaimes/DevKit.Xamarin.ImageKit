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
        public byte[] ConvertJpgToPng(byte[] image)
        {
            UIImage uiImage = image.ToImage();
            return uiImage.AsPNG().ToArray();
        }

        /// <summary>
        /// Converts the png image to jpg image.
        /// </summary>
        /// <returns>The jpg image.</returns>
        /// <param name="image">The original image.</param>
        public byte[] ConvertPngToJpg(byte[] image, int quality)
        {
            UIImage uiImage = image.ToImage();
            nfloat fQuality = quality / 100;
            return uiImage.AsJPEG(fQuality).ToArray();
        }
    }
}