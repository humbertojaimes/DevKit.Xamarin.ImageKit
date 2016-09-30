using DemoImageKit.Interfaces;
using DemoImageKit.iOS;
using DevKit.Xamarin.ImageKit.iOS.Utils;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(ImageLoader))]

namespace DemoImageKit.iOS
{
    public class ImageLoader : IImageLoader
    {
        public async Task<byte[]> GetImage()
        {
            UIKit.UIImage image = UIKit.UIImage.FromBundle("ImageJPG.jpg");
            return image.AsJPEG().ToArray();
        }

        public async Task<string[]> GetImageDetails(byte[] image)
        {
            UIKit.UIImage uiImage = await image.ToImageAsync();
            string[] data = new string[3]
            {
                uiImage.Size.Width.ToString(),
                uiImage.Size.Height.ToString(),
                image.Length.ToString()
            };
            return data;
        }
    }
}