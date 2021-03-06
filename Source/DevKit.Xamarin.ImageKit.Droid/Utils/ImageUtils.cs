using Android.Graphics;
using System.IO;
using System.Threading.Tasks;

namespace DevKit.Xamarin.ImageKit.Droid.Utils
{
    public static class ImageUtils
    {
        public static Bitmap ToBitmap(this byte[] image)
        {
            Bitmap resultBitmap =
                BitmapFactory.DecodeByteArray(image, 0, image.Length);
            
            return resultBitmap;
        }

        public static byte[] ToByteArray(this Bitmap image, Abstractions.ImageFormat format, int quality = 100)
        {
            byte[] resultArray = null;
            using (MemoryStream outStream = new MemoryStream())
            {
                Bitmap.CompressFormat compressFormat = format == Abstractions.ImageFormat.JPG ? Bitmap.CompressFormat.Jpeg : Bitmap.CompressFormat.Png;
                image.Compress(compressFormat,
                               quality, outStream);
                resultArray = outStream.ToArray();
            };
            return resultArray;
        }
    }
}