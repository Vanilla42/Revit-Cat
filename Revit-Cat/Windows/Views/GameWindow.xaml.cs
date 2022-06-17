using System.Windows;

namespace Revit_Cat
{
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();

            DataContext = new GameViewModel();
        }
    }
}
