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
			var drawable =
				(BitmapDrawable)context.Resources.GetDrawable
					   (Resource.Drawable.ImageJPG);
			return await drawable.Bitmap.ToByteArray(DevKit.Xamarin.ImageKit.Abstractions.ImageFormat.JPG, 100);
		}

		public async Task<string[]> GetImageDetails(byte[] image)
		{
			Bitmap bmpImage = await image.ToBitmap();
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

