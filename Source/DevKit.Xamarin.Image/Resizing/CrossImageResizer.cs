using DevKit.Xamarin.ImageKit.Abstractions;
using System;

namespace DevKit.Xamarin.ImageKit
{
    public class CrossImageResizer
    {
        private static Lazy<IImageResizer> TTS = new Lazy<IImageResizer>(() => CreateImageResizer(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static IImageResizer Current
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

        private static IImageResizer CreateImageResizer()
        {
#if PORTABLE
			return null;
#else
            return new ImageResizer();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the DevKit.Xamarin.ImageKit NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}