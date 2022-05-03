using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Cat
{
    static class DockablePaneRegistrator
    {
        public static void Register(UIControlledApplication application)
        {
            MainPage dockPage = new MainPage(application);
            DockablePaneId dpid = new DockablePaneId(new Guid("{D7C963CE-B7CA-426A-8D51-6E8254D21157}"));
            application.RegisterDockablePane(dpid, "Cat", dockPage as IDockablePaneProvider);
        }
    }
}
