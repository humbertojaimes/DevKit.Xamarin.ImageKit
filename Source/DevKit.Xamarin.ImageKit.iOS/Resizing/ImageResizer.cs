using DevKit.Xamarin.ImageKit.Abstractions;
using DevKit.Xamarin.ImageKit.iOS.Utils;
using System;
using System.Threading.Tasks;
using UIKit;

namespace DevKit.Xamarin.ImageKit
{
    public class ImageResizer : IImageResizer
    {
        /// <summary>
        /// Reduces the quality of a Jpg image.
        /// </summary>
        /// <returns>The low quality image.</returns>
        /// <param name="originalImage">Original image.</param>
        /// <param name="newQuality">New quality from 1 to 100.</param>
        public async Task<byte[]> ReduceJPGQualityAsync(byte[] originalImage, int newQuality)
        {
            if (newQuality > 100 || newQuality < 1)
                throw new Exception("Invalid quality value");
            UIImage uiImage = await originalImage.ToImageAsync();
            nfloat fNewQuality = newQuality / 100;
            return uiImage.AsJPEG(fNewQuality).ToArray();
        }

        /// <summary>
        /// Resizes an image.
        /// </summary>
        /// <returns>The resized image.</returns>
        /// <param name="originalImage">Original image.</param>
        /// <param name="newHeight">New height.</param>
        /// <param name="newWidth">New width.</param>
        /// <param name="imageFormat">Image format Jpg or Png.</param>
        public async Task<byte[]> ResizeImageAsync(byte[] originalImage, int newHeight, int newWidth, ImageFormat imageFormat)
        {
            byte[] resulImage = null;
            UIKit.UIImage uiImage = await originalImage.ToImageAsync();
            UIGraphics.BeginImageContext(new CoreGraphics.CGSize(newWidth, newHeight));
            uiImage.Draw(new CoreGraphics.CGRect(0, 0, newWidth, newHeight));
            UIImage resultUIImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            if (imageFormat == ImageFormat.JPG)
                resulImage = resultUIImage.AsJPEG().ToArray();
            else
                resulImage = resultUIImage.AsPNG().ToArray();

            return resulImage;
        }

        /// <summary>
        /// Scales an image.
        /// </summary>
        /// <returns>The scaled image.</returns>
        /// <param name="originalImage">Original image.</param>
        /// <param name="finalImagePercentage">Final image percentage.</param>
        /// <param name="imageFormat">Image format Jpg or Png.</param>
        public async Task<byte[]> ScaleImageAsync(byte[] originalImage, double finalImagePercentage, ImageFormat imageFormat)
        {
            UIKit.UIImage uiImage = await originalImage.ToImageAsync();
            nfloat width = uiImage.Size.Width;
            nfloat height = uiImage.Size.Height;
            int scaleWidth = Convert.ToInt16(width * (finalImagePercentage * .01));
            int scaleHeight = Convert.ToInt16(height * (finalImagePercentage * .01));
            return await ResizeImageAsync(originalImage, scaleHeight, scaleWidth, imageFormat);
        }
    }
}