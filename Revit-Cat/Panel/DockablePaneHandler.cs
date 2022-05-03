using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Revit_Cat
{
    /// <summary>
    /// Show dockable dialog
    /// </summary>
    [Transaction(TransactionMode.ReadOnly)]
    public class DockablePaneShow : IExternalCommand
    {
        Guid guid = new Guid("{D7C963CE-B7CA-426A-8D51-6E8254D21157}");
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            DockablePane dp = commandData.Application.GetDockablePane(new DockablePaneId(guid));

            dp.Show();

            return Result.Succeeded;
        }
    }

    /// <summary>
    /// Hide dockable dialog
    /// </summary>
    [Transaction(TransactionMode.ReadOnly)]
    public class DockablePaneHide : IExternalCommand
    {
        Guid guid = new Guid("{D7C963CE-B7CA-426A-8D51-6E8254D21157}");

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            DockablePane dp = commandData.Application.GetDockablePane(new DockablePaneId(guid));

            dp.Hide();

            return Result.Succeeded;
        }
    }
}
