using DevKit.Xamarin.ImageKit.Abstractions;
using System;

namespace DevKit.Xamarin.ImageKit
{
    public class CrossImageConverter
    {
        private static Lazy<IImageConverter> TTS = new Lazy<IImageConverter>(() => CreateImageConverter(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static IImageConverter Current
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

        private static IImageConverter CreateImageConverter()
        {
#if PORTABLE
            return null;
#else
            return new ImageConverter();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the DevKit.Xamarin.ImageKit NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}