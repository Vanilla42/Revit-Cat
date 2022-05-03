using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;

namespace Revit_Cat
{
    /// <summary>
    /// Startup class for all Revit plugin (described in .addin file)
    /// </summary>
    /// <returns>After initializing on startup returns Result.Succeeded</returns>
    public class Main : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            // Initialize whole plugin's user interface
            SetupInterface ui = new SetupInterface();
            ui.Initialize(application);

            DockablePaneRegistrator.Register(application);

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
