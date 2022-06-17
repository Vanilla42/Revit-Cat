using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Revit_Cat.Windows
{
    public partial class Cell : UserControl
    {
        private bool _hasMouse;
        public bool HasMouse
        {
            get { return _hasMouse; }
            set { _hasMouse = value; }
        }

        private BitmapImage _cellImage;
        public BitmapImage CellImage { get => _cellImage; set => _cellImage = value; }

        public Cell()
        {
            CellImage = ResourceImage.GetImage("Images.Revit_Cat_Game_Cell.jpg");
        }

        private void HandleMouseLeave(object sender, MouseEventArgs e)
        {
            BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDDDDDD"));
        }
        private void HandleMouseEnter(object sender, MouseEventArgs e)
        {
            BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF888888"));
        }
    }
}
