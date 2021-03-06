using System;
using System.Threading.Tasks;
using DevKit.Xamarin.ImageKit.iOS.Utils;

namespace DevKit.Xamarin.ImageKit
{
    public class ImageData : IImageData
    {
        public ImageDataResult GetImageDetails(byte[] image)
        {
            UIKit.UIImage uiImage = image.ToImage();
            ImageDataResult data = new ImageDataResult
            {
                Width = (int)uiImage.Size.Width,
                Heigth = (int)uiImage.Size.Height
            };
            return data;
        }
    }
}
