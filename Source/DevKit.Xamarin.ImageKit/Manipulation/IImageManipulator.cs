using System;
using System.Threading.Tasks;
using DevKit.Xamarin.ImageKit.Abstractions;

namespace DevKit.Xamarin.ImageKit.Manipulation
{
    public interface IImageManipulator
    {
        
        /// <summary>
        /// Totate an image 90 degrees.
        /// </summary>
        /// <returns>The rotated image.</returns>
        /// <param name="originalImage">Original image.</param>
        /// <param name="orientation">Left o Rigth rotation. </param>
        /// <param name="imageFormat">Image format Jpg or Png.</param>
        byte[] RotateImage(byte[] originalImage, SideOrientation orientation , ImageFormat imageFormat);

    }
}
