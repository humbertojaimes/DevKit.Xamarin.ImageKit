using DevKit.Xamarin.ImageKit.Abstractions;
using DevKit.Xamarin.ImageKit.Manipulation;
using DevKit.Xamarin.ImageKit.UWP.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace DevKit.Xamarin.ImageKit.Manipulation
{
    class ImageManipulator : IImageManipulator
    {
        public async Task<byte[]> RotateImageAsync(byte[] originalImage, SideOrientation orientation, ImageFormat imageFormat)
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
                encoder.BitmapTransform.Rotation = orientation == SideOrientation.RotateToRigth ? BitmapRotation.Clockwise90Degrees : BitmapRotation.Clockwise270Degrees;
                await encoder.FlushAsync();
                resizedStream.Seek(0);
                resultImage = new byte[resizedStream.Size];
                await resizedStream.ReadAsync(resultImage.AsBuffer(), (uint)resizedStream.Size, InputStreamOptions.None);
            }

            return resultImage;
        }
    }
}
