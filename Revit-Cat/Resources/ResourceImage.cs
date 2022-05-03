using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace Revit_Cat
{
    // Gets the embedded resource image from the BIM Leaders Resources assembly based on user provided file name with extension
    public static class ResourceImage
    {
        // Gets the icon image from the users assembly
        public static BitmapImage GetImage(string name)
        {
            BitmapImage image = new BitmapImage();

            // Create the resource reader
            Stream stream = ResourceAssembly.GetAssembly().GetManifestResourceStream(ResourceAssembly.GetNamespace() + "Resources." + name);

            // Construct and return image
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            // Return constructed BitmapImage
            return image;
        }
    }
}