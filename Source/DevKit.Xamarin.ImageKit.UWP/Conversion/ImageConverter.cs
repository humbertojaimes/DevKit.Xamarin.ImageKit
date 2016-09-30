using DevKit.Xamarin.ImageKit.Abstractions;
using DevKit.Xamarin.ImageKit.UWP.Utils;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace DevKit.Xamarin.ImageKit
{
    internal class ImageConverter : IImageConverter
    {
        public async Task<byte[]> ConvertJpgToPngAsync(byte[] image)
        {
            WriteableBitmap bitmapImage = await image.ToBitmapImageAsync();
            return await bitmapImage.ToByteArrayAsync(ImageFormat.PNG);
        }

        public async Task<byte[]> ConvertPngToJpgAsync(byte[] image, int quality)
        {
            WriteableBitmap bitmapImage = await image.ToBitmapImageAsync();

            return await bitmapImage.ToByteArrayAsync(ImageFormat.JPG);
        }
    }
}