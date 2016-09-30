using DemoImageKit.Interfaces;
using DevKit.Xamarin.ImageKit;
using DevKit.Xamarin.ImageKit.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace DemoImageKit
{
    public enum ImagePluginFunctions
    {
        Resize,
        Scale,
        ReduceJpgQuality,
        ConvertFromJpgToPng,
        ConvertFromPngToJpg,
    }

    public partial class DemoImageKitPage : ContentPage
    {
        public DemoImageKitPage()
        {
            InitializeComponent();

            initialize();
        }

        private async void initialize()
        {
            List<string> imagePluginFunctions = new List<string>
            {
                ImagePluginFunctions.ConvertFromJpgToPng.ToString(),
                ImagePluginFunctions.ConvertFromPngToJpg.ToString(),
                ImagePluginFunctions.ReduceJpgQuality.ToString(),
                ImagePluginFunctions.Resize.ToString(),
                ImagePluginFunctions.Scale.ToString()
            };

            imagePluginFunctions.All((arg) => { pkrMethods.Items.Add(arg); return true; });
            pkrMethods.SelectedIndex = 0;
            imageLoader = DependencyService.Get<IImageLoader>();
            sampleImage = await imageLoader.GetImage();
            loadImageOnPage(sampleImage);
        }

        private IImageLoader imageLoader;
        private byte[] sampleImage;

        private async void loadImageOnPage(byte[] image)
        {
            ImageSource imageSource = ImageSource.FromStream(() => { return new MemoryStream(image); });
            imDisplay.Source = imageSource;
            string[] imageInformation = await imageLoader.GetImageDetails(image);
            lbWidth.Text = "Width " + imageInformation[0];
            lbHeight.Text = "Heigth " + imageInformation[1];
            lbArrayLength.Text = "Array Length " + imageInformation[2];
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            ImageFormat format = ImageFormat.JPG;
            if (pkrMethods.SelectedIndex != -1)
                switch ((ImagePluginFunctions)Enum.Parse(typeof(ImagePluginFunctions), pkrMethods.Items.ElementAt(pkrMethods.SelectedIndex)))
                {
                    case ImagePluginFunctions.ConvertFromJpgToPng:
                        byte[] pngImage = await CrossImageConverter.Current.ConvertJpgToPngAsync(sampleImage);
                        loadImageOnPage(pngImage);
                        break;

                    case ImagePluginFunctions.ConvertFromPngToJpg:
                        byte[] png = await CrossImageConverter.Current.ConvertJpgToPngAsync(sampleImage);
                        byte[] newJpg = await CrossImageConverter.Current.ConvertPngToJpgAsync(png, 100);
                        loadImageOnPage(newJpg);
                        break;

                    case ImagePluginFunctions.ReduceJpgQuality:
                        byte[] lessQualityImage = await CrossImageResizer.Current.ReduceJPGQualityAsync(sampleImage, 50);
                        loadImageOnPage(lessQualityImage);
                        break;

                    case ImagePluginFunctions.Resize:
                        byte[] reducedImage = await CrossImageResizer.Current.ResizeImageAsync(sampleImage, 320, 320, format);
                        loadImageOnPage(reducedImage);
                        break;

                    case ImagePluginFunctions.Scale:
                        byte[] scaledImage = await CrossImageResizer.Current.ScaleImageAsync(sampleImage, 50, format);
                        loadImageOnPage(scaledImage);
                        break;
                }
        }
    }
}