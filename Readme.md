# DevKit.Xamarin.ImageKit

The ImageKit for Xamarin contains basic functionality to rezize images and convert images betwen JPG and PNG formats in Xamarin.Android, Xamarin.iOS, UWP and Xamarin.Forms.

### Usage
- Xamarin.Forms Portable Class Library:
  - Add DevKit.Xamarin.ImageKit.Abstractions
  - Add DevKit.Xamarin.ImageKit (from libs/DevKit.Xamarin.ImageKit Folder)

- Droid Project:
  - Add DevKit.Xamarin.ImageKit.Abstractions
  - Add DevKit.Xamarin.ImageKit (from libs/DevKit.Xamarin.ImageKit.Droid Folder)
  
- iOS Project:
  - Add DevKit.Xamarin.ImageKit.Abstractions
  - Add DevKit.Xamarin.ImageKit (from libs/DevKit.Xamarin.ImageKit.iOS Folder)
  
- UWP Project:
  - Add DevKit.Xamarin.ImageKit.Abstractions
  - Add DevKit.Xamarin.ImageKit (from libs/DevKit.Xamarin.ImageKit.UWP Folder)
  
### Functions

- Conversion
```
//Convert Image from JPG to PNG
byte[] pngImage = await CrossImageConverter.Current.ConvertJpgToPng(sampleImage);
```
```
//Convert Image from PNG to JPG. It can receive the quality of the result image from 0 to 100
byte[] newJpg = await CrossImageConverter.Current.ConvertPngToJpg(png, 100);
```
- Resizing
```
//Convert Image from PNG to JPG. It can receive the quality of the result image from 0 to 100
byte[] newJpg = await CrossImageConverter.Current.ConvertPngToJpg(png, 100);
```
```
//Reduce de quelity of JP Image. Quality is a value from 0 to 100
byte[] lessQualityImage = await CrossImageResizer.Current.ReduceJPGQuality(sampleImage, 50);
```
```
//Resize an image with custom width and height
byte[] reducedImage = await CrossImageResizer.Current.ResizeImage(sampleImage, 320, 320, format);
```
```
//Resize an image base on a percentage from the original image
byte[] scaledImage = await CrossImageResizer.Current.ScaleImage(sampleImage, 50, format);
```

### Extension methods for platforms
I created some extension methods to facilitate conversion from image native classes to byte[] and vice versa.

These are the method(s) per platform in DevKit.Xamarin.ImageKit dll

- Droid (namespace DevKit.Xamarin.ImageKit.Droid.Utils)
  - ToBitmap() returns a Bitmap from byte[]  
  - ToByteArray(Abstractions.ImageFormat, int quality) returns a byte[] from a Bitmap instace
- iOS (namespace DevKit.Xamarin.ImageKit.iOS.Utils)
  - ToImage() returns a UIImage from byte[]
- UWP (namespace DevKit.Xamarin.ImageKit.UWP.Utils)
  - ToBitmapImage() returns a WriteableBitmap from byte[]
  - ToByteArray(Abstractions.ImageFormat, int quality) returns a byte[] from a WriteableBitmap instace 

Feel free to contribute, improve or use this code for your projects.

