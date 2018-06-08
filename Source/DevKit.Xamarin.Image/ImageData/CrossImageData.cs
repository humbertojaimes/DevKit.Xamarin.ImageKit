using DevKit.Xamarin.ImageKit.Abstractions;
using System;

namespace DevKit.Xamarin.ImageKit
{
    public class CrossImageData
    {
        private static Lazy<IImageData> TTS = new Lazy<IImageData>(() => CreateImageData(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		/// <summary>
		/// Current settings to use
		/// </summary>
        public static IImageData Current
		{
			get
			{
				var ret = TTS.Value;
				if (ret == null)
				{
					throw NotImplementedInReferenceAssembly();
				}
				return ret;
			}
		}

        private static IImageData CreateImageData()
		{
#if PORTABLE
			return null;
#else
            return new ImageData();
#endif
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the DevKit.Xamarin.ImageKit NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
    }
}