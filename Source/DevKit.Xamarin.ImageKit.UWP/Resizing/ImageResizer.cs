using DevKit.Xamarin.ImageKit.Abstractions;
using DevKit.Xamarin.ImageKit.UWP.Utils;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace DevKit.Xamarin.ImageKit
{
    public class ImageResizer : IImageResizer
    {
        public async Task<byte[]> ReduceJPGQualityAsync(byte[] originalImage, int newQuality)
        {
            WriteableBitmap bitmapImage = await originalImage.ToBitmapImageAsync();
            return await bitmapImage.ToByteArrayAsync(ImageFormat.JPG, newQuality);
        }

        public async Task<byte[]> ResizeImageAsync(byte[] originalImage, int newHeight, int newWidth, ImageFormat imageFormat)
        {
            byte[] resultImage = null;
            WriteableBitmap bitmapImage = await originalImage.ToBitmapImageAsync();

            MemoryStream memoryStream = new MemoryStream(originalImage);

            using (IRandomAccessStream randomAccessStream = memoryStream.AsRandomAccessStream())
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(randomAccessStream);
                var resizedStream = new InMemoryRandomAccessStream();
                BitmapEncoder encoder = await BitmapEncoder.CreateForTranscodingAsync(resizedStream, decoder);
                encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Linear;
                encoder.BitmapTransform.ScaledHeight = (uint)newHeight;
                encoder.BitmapTransform.ScaledWidth = (uint)newWidth;
                await encoder.FlushAsync();
                resizedStream.Seek(0);
                resultImage = new byte[resizedStream.Size];
                await resizedStream.ReadAsync(resultImage.AsBuffer(), (uint)resizedStream.Size, InputStreamOptions.None);
            }

            return resultImage;
        }

        public async Task<byte[]> ScaleImageAsync(byte[] originalImage, double finalImagePercentage, ImageFormat imageFormat)
        {
            WriteableBitmap bitmapImage = await originalImage.ToBitmapImageAsync();
            int scaleWidth = Convert.ToInt16(bitmapImage.PixelWidth * (finalImagePercentage * .01));
            int scaleHeight = Convert.ToInt16(bitmapImage.PixelHeight * (finalImagePercentage * .01));

            return await ResizeImageAsync(originalImage, scaleHeight, scaleWidth, imageFormat);
        }
    }
}