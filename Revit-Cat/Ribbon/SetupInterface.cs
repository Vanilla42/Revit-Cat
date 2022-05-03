using Autodesk.Revit.UI;
using System.Reflection;

namespace Revit_Cat
{
    public class SetupInterface
    {
        public SetupInterface() { }
        /// <summary>
        /// Creating Ribbon tabs, panels and buttons.
        /// </summary>
        public void Initialize(UIControlledApplication application)
        {
            // Create Ribbon Tab
            string tabName = "Cat";
            application.CreateRibbonTab(tabName);
            //string path = Assembly.GetExecutingAssembly().Location;

            // Create Ribbon Panel
            string panelName = "Cat";
            RibbonPanel panel = application.CreateRibbonPanel(tabName, panelName);

            // Populate button data model
            RevitPushButtonDataModel buttonData01 = new RevitPushButtonDataModel
            {
                Label = "Here, kitty!",
                Panel = panel,
                ToolTip = "Call a cat.",
                IconImageName = "Icons.Revit_Cat_Call.png",
                CommandNamespacePath = "Revit_Cat.DockablePaneShow"
            };

            // Populate button data model
            RevitPushButtonDataModel buttonData02 = new RevitPushButtonDataModel
            {
                Label = "Sleep, kitty!",
                Panel = panel,
                ToolTip = "Make cat sleep.",
                IconImageName = "Icons.Revit_Cat_Sleep.png",
                CommandNamespacePath = "Revit_Cat.DockablePaneHide"
            };

            // Create buttons from provided data
            RevitPushButton.Create(buttonData01);
            RevitPushButton.Create(buttonData02);
        }
    }
}
