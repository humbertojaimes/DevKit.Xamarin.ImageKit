using System;
using System.Threading.Tasks;

namespace DevKit.Xamarin.ImageKit
{
    public interface IImageData
    {
		/// <summary>
		/// Converts the jpg image to png image.
		/// </summary>
		/// <returns>The png image.</returns>
		/// <param name="image">The original image.</param>
        Task<ImageDataResult> GetImageDetails(byte[] image);
    }
}
