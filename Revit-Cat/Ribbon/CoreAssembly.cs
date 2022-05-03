using System.Reflection;

namespace Revit_Cat
{
    // The core assembly helper methods
    public static class CoreAssembly
    {
        public static string GetAssemblyLocation()
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }
}
