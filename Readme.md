# DevKit.Xamarin.ImageKit

The ImageKit for Xamarin contains basic functionality to resize images and convert images betwen JPG and PNG formats in Xamarin.Android, Xamarin.iOS, UWP and Xamarin.Forms.

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
```csharp
//Convert Image from JPG to PNG
byte[] pngImage = await CrossImageConverter.Current.ConvertJpgToPng(sampleImage);
```
```
//Convert Image from PNG to JPG. It can receive the quality of the result image from 0 to 100
byte[] newJpg = await CrossImageConverter.Current.ConvertPngToJpgAsync(png, 100);
```csharp
- Resizing
```csharp
//Convert Image from PNG to JPG. It can receive the quality of the result image from 0 to 100
byte[] newJpg = await CrossImageConverter.Current.ConvertPngToJpgAsync(png, 100);
```
```csharp
//Reduce de quelity of JP Image. Quality is a value from 0 to 100
byte[] lessQualityImage = await CrossImageResizer.Current.ReduceJPGQualityAsync(sampleImage, 50);
```
```csharp
//Resize an image with custom width and height
byte[] reducedImage = await CrossImageResizer.Current.ResizeImageAsync(sampleImage, 320, 320, format);
```
```
//Resize an image base on a percentage from the original image
byte[] scaledImage = await CrossImageResizer.Current.ScaleImageAsync(sampleImage, 50, format);
```

- Manipulation
```csharp
//Rotate an image 90 degrees to it's rigth or left side
byte[] leftRotatedImage = await CrossImageManipulation.Current.RotateImageAsync(sampleImage, SideOrientation.RotateToLeft, format);
```

- Image Details
```csharp
//Returns the width and heigth of the image 
var imageInformation = await CrossImageData.Current.GetImageDetails(image);
            lbWidth.Text = "Width " + imageInformation.Width;
            lbHeight.Text = "Heigth " + imageInformation.Heigth;
```

### Extension methods for platforms
I created some extension methods to facilitate conversion from image native classes to byte[] and vice versa.

These are the method(s) per platform in DevKit.Xamarin.ImageKit dll

- Droid (namespace DevKit.Xamarin.ImageKit.Droid.Utils)
  - ToBitmap() returns a Bitmap from byte[]  
  - ToByteArrayAsync(Abstractions.ImageFormat, int quality) returns a byte[] from a Bitmap instace
- iOS (namespace DevKit.Xamarin.ImageKit.iOS.Utils)
  - ToImageAsync() returns a UIImage from byte[]
- UWP (namespace DevKit.Xamarin.ImageKit.UWP.Utils)
  - ToBitmapImageAsync() returns a WriteableBitmap from byte[]
  - ToByteArrayAsync(Abstractions.ImageFormat, int quality) returns a byte[] from a WriteableBitmap instace 

Feel free to contribute, improve or use this code for your projects.

