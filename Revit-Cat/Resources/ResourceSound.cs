using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace Revit_Cat
{
    // Gets the embedded resource image from the BIM Leaders Resources assembly based on user provided file name with extension
    public static class ResourceSound
    {
        // Gets the icon image from the users assembly
        public static Stream GetSound(string name)
        {
            // Create the resource reader
            Stream stream = ResourceAssembly.GetAssembly().GetManifestResourceStream(ResourceAssembly.GetNamespace() + "Resources.Sounds." + name);

            // Return Stream
            return stream;
        }
    }
}