using DevKit.Xamarin.ImageKit.UWP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace DevKit.Xamarin.ImageKit
{
    public class ImageData : IImageData
    {
        public async Task<ImageDataResult> GetImageDetails(byte[] image)
        {
            WriteableBitmap bitmapImage = await image.ToBitmapImageAsync();

            ImageDataResult data = new ImageDataResult
            {
                Width = bitmapImage.PixelWidth,
                Heigth = bitmapImage.PixelHeight
            };
            return data;
        }
    }
}
