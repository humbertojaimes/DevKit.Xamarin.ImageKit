using System;
using System.Threading.Tasks;
using Android.Graphics;
using DevKit.Xamarin.ImageKit.Droid.Utils;

namespace DevKit.Xamarin.ImageKit
{
    public class ImageData : IImageData
    {
      

        public async Task<ImageDataResult> GetImageDetails(byte[] image)
        {
			Bitmap bmpImage = await image.ToBitmapAsync();
			ImageDataResult data = new ImageDataResult
			{
                Width = bmpImage.Width,
                Heigth = bmpImage.Height
			};
			return data;
        }
    }
}
