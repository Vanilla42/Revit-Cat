using System;
using Autodesk.Revit.UI;

namespace Revit_Cat
{
    // Revit push button methods
    public static class RevitPushButton
    {
        // Create the push button data provided in <see cref="RevitPushButtonDataModel">
        public static PushButton Create(RevitPushButtonDataModel data)
        {
            // The button name based on unique ID
            string btnDataName = Guid.NewGuid().ToString();

            // Sets the button data
            PushButtonData btnData = new PushButtonData(btnDataName, data.Label, CoreAssembly.GetAssemblyLocation(), data.CommandNamespacePath)
            {
                ToolTip = data.ToolTip,
                LongDescription = data.LongDescription,
                LargeImage = ResourceImage.GetImage(data.IconImageName),
                AvailabilityClassName = data.AvailabilityClassName
            };

            // Return created button and host it on panel provided in required data model
            return data.Panel.AddItem(btnData) as PushButton;
        }
    }
}
