using DevKit.Xamarin.ImageKit.Abstractions;
using DevKit.Xamarin.ImageKit.UWP.Utils;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace DevKit.Xamarin.ImageKit
{
    internal class ImageConverter : IImageConverter
    {
        public async Task<byte[]> ConvertJpgToPng(byte[] image)
        {
            WriteableBitmap bitmapImage = await image.ToBitmapImage();
            return await bitmapImage.ToByteArray(ImageFormat.PNG);
        }

        public async Task<byte[]> ConvertPngToJpg(byte[] image, int quality)
        {
            WriteableBitmap bitmapImage = await image.ToBitmapImage();

            return await bitmapImage.ToByteArray(ImageFormat.JPG);
        }
    }
}