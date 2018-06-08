using System;
using DevKit.Xamarin.ImageKit.Manipulation;

namespace DevKit.Xamarin.Image.Manipulation
{
    public class CrossImageManipulation
    {
        private static Lazy<IImageManipulator> TTS = new Lazy<IImageManipulator>(() => CreateImageResizer(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static IImageManipulator Current
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

        private static IImageManipulator CreateImageResizer()
        {
#if PORTABLE
            return null;
#else
            return new ImageManipulator();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the DevKit.Xamarin.ImageKit NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
