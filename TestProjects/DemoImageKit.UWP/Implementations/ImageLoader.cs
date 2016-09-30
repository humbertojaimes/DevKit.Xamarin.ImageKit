using DemoImageKit.Interfaces;
using DemoImageKit.UWP.Implementations;
using DevKit.Xamarin.ImageKit.UWP.Utils;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

[assembly: Xamarin.Forms.Dependency(typeof(ImageLoader))]

namespace DemoImageKit.UWP.Implementations
{
    public class ImageLoader : IImageLoader
    {
        public async Task<byte[]> GetImage()
        {
            Windows.UI.Xaml.Controls.Image image = new Windows.UI.Xaml.Controls.Image();
            Uri url = new Uri("ms-appx:///Assets/ImageJPG.jpg");
            WriteableBitmap bitmapImage = new WriteableBitmap(1, 1);
            var storageFile = await StorageFile.GetFileFromApplicationUriAsync(url);
            using (var stream = await storageFile.OpenReadAsync())
            {
                await bitmapImage.SetSourceAsync(stream);
            }

            return await bitmapImage.ToByteArrayAsync(DevKit.Xamarin.ImageKit.Abstractions.ImageFormat.JPG, 100);
        }

        public async Task<string[]> GetImageDetails(byte[] image)
        {
            WriteableBitmap bitmapImage = await image.ToBitmapImageAsync();
            string[] data = new string[3]
            {
                bitmapImage.PixelWidth.ToString(),
                bitmapImage.PixelHeight.ToString(),
                image.Length.ToString()
            };
            return data;
        }
    }
}