using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Revit_Cat
{
    public class CellViewModel : INotifyPropertyChanged
    {
        public int IndexColumn { get; set; }
        public int IndexRow { get; set; }

        private BitmapImage _image;
        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }
        private bool _isMouse;
        public bool IsMouse
        {
            get { return _isMouse; }
            set
            {
                _isMouse = value;
                OnPropertyChanged("IsMouse");
            }
        }

        public CellViewModel()
        {
            Image = ResourceImage.GetImage("Images.Revit_Cat_Game_Cell");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
