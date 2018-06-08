using System;
using System.Threading.Tasks;
using DevKit.Xamarin.ImageKit.Abstractions;
using DevKit.Xamarin.ImageKit.iOS.Utils;
using DevKit.Xamarin.ImageKit.Manipulation;
using UIKit;
using CoreGraphics;

namespace DevKit.Xamarin.ImageKit.Manipulation
{
    public class ImageManipulator : IImageManipulator
    {
        public async Task<byte[]> RotateImageAsync(byte[] originalImage
                                                   , SideOrientation orientation, ImageFormat imageFormat)
        {
            byte[] resulImage = null;
            UIKit.UIImage uiImage = await originalImage.ToImageAsync();

            CGBitmapContext bitmapContext = new CGBitmapContext(IntPtr.Zero, (int)uiImage.Size.Height, (int)uiImage.Size.Width, uiImage.CGImage.BitsPerComponent, uiImage.CGImage.BytesPerRow, uiImage.CGImage.ColorSpace, uiImage.CGImage.AlphaInfo);
            bitmapContext.RotateCTM(orientation == SideOrientation.RotateToRigth ? (-(float)Math.PI / 2) : (float)Math.PI / 2);
            bitmapContext.TranslateCTM(orientation == SideOrientation.RotateToRigth ? -(int)uiImage.Size.Width : 0,
                                       orientation == SideOrientation.RotateToRigth ? 0 : -(int)uiImage.Size.Height);

            bitmapContext.DrawImage(new CoreGraphics.CGRect(0, 0, (int)uiImage.Size.Width, (int)uiImage.Size.Height),uiImage.CGImage);

            UIImage resultUIImage = UIImage.FromImage(bitmapContext.ToImage());

            if (imageFormat == ImageFormat.JPG)
                resulImage = resultUIImage.AsJPEG().ToArray();
            else
                resulImage = resultUIImage.AsPNG().ToArray();

            return resulImage;
        }
    }
}
