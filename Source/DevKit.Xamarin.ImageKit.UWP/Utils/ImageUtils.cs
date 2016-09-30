using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace DevKit.Xamarin.ImageKit.UWP.Utils
{
    public static class ImageUtils
    {
        public async static Task<WriteableBitmap> ToBitmapImage(this byte[] image)
        {
            WriteableBitmap resultBitmap = new WriteableBitmap(1, 1);
            using (IRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                await ms.WriteAsync(image.AsBuffer());
                ms.Seek(0); // Just to be sure.
                resultBitmap.SetSource(ms);
            }
            return resultBitmap;
        }

        public async static Task<byte[]> ToByteArray(this WriteableBitmap image, Abstractions.ImageFormat format, int quality = 100)
        {
            byte[] resultArray = null;
            WriteableBitmap writeableBitmap = image;

            using (IRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                try
                {
                    byte[] bytes;
                    using (Stream stream = image.PixelBuffer.AsStream())
                    {
                        bytes = new byte[(uint)stream.Length];
                        await stream.ReadAsync(bytes, 0, bytes.Length);
                    }

                    BitmapPropertySet propertySet = new BitmapPropertySet();
                    BitmapTypedValue qualityValue = new BitmapTypedValue(
                        quality * .01,
                        Windows.Foundation.PropertyType.Single
                        );
                    propertySet.Add("ImageQuality", qualityValue);

                    BitmapEncoder encoder = null;
                    if (format == Abstractions.ImageFormat.PNG)
                        encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, ms);
                    else
                        encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, ms, propertySet);

                    encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                        BitmapAlphaMode.Ignore,
                        (uint)image.PixelWidth,
                        (uint)image.PixelHeight,
                        96,
                        96,
                        bytes);

                    await encoder.FlushAsync();
                    resultArray = new byte[ms.AsStream().Length];
                    await ms.AsStream().ReadAsync(resultArray, 0, resultArray.Length);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            return resultArray;
        }
    }
}