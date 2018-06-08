using System;
using System.IO;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Graphics.Drawables;
using DemoImageKit.Droid;
using DemoImageKit.Interfaces;
using DevKit.Xamarin.ImageKit.Droid.Utils;


[assembly: Xamarin.Forms.Dependency(typeof(ImageLoader))]
namespace DemoImageKit.Droid
{

	public class ImageLoader : IImageLoader
	{


		public async Task<byte[]> GetImage()
		{
			var context = Xamarin.Forms.Forms.Context;

            BitmapFactory.Options options = new BitmapFactory.Options();

            options.InScaled = false;
            var drawable = new BitmapDrawable(BitmapFactory.DecodeResource(Android.App.Application.Context.Resources,Resource.Drawable.ImageJPG,options));
			return await drawable.Bitmap.ToByteArrayAsync(DevKit.Xamarin.ImageKit.Abstractions.ImageFormat.JPG, 100);
		}

		public async Task<string[]> GetImageDetails(byte[] image)
		{
			Bitmap bmpImage = await image.ToBitmapAsync();
			string[] data = new string[3]
			{
				bmpImage.Width.ToString(),
				bmpImage.Height.ToString(),
				image.Length.ToString()
			};
			return data;
		}

	}
}

