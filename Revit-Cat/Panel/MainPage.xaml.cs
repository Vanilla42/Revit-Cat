using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Autodesk.Revit.UI;

namespace Revit_Cat
{
    public partial class MainPage : Page, IDockablePaneProvider
    {
        private Guid m_targetGuid;
        private DockPosition m_position = DockPosition.Bottom;
        private int m_left = 1;
        private int m_right = 1;
        private int m_top = 1;
        private int m_bottom = 1;

        public MainPage(UIControlledApplication uiapp)
        {
            InitializeComponent();

            DataContext = new MainPageData(uiapp);
        }
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this as FrameworkElement;
            data.InitialState = new DockablePaneState()
            {
                DockPosition = DockPosition.Tabbed,
                TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser
            };
        }
        public void SetInitialDockingParameters(int left, int right, int top, int bottom, DockPosition position, Guid targetGuid)
        {
            m_position = position;
            m_left = left;
            m_right = right;
            m_top = top;
            m_bottom = bottom;
            m_targetGuid = targetGuid;
        }

        private void mouseClick(object sender, MouseButtonEventArgs e)
        {
            TaskDialog.Show("Cat", "Meow!");
        }

        private void DockableDialogs_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Milk_Click(object sender, RoutedEventArgs e)
        {
            TaskDialog.Show("Cat", "Mrrr..Meow!");
        }

        private void Button_Whiskas_Click(object sender, RoutedEventArgs e)
        {
            TaskDialog.Show("Cat", "Purrrr!");
        }
    }
}
