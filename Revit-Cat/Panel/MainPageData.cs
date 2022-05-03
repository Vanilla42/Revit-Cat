using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;

namespace Revit_Cat
{
    public class MainPageData //: INotifyPropertyChanged
    {
        private BitmapImage _catImage;
        public BitmapImage CatImage { get => _catImage; set => _catImage = value; }

        public MainPageData(UIControlledApplication uicapp)
        {
            CatImage = ResourceImage.GetImage("Images.Revit_Cat_Cat.jpg");

            //uicapp.ControlledApplication.DocumentSynchronizedWithCentral += (s, e) => { ChangeCatSynchronized(); };
        }
        /*
        private void ChangeCatSynchronized()
        {
            CatImage = ResourceImage.GetImage("Images.Revit_Cat_Synchronized.jpg");

            Timer mTimer = new Timer(3000);
            mTimer.Elapsed += ChangeCatCat;
            mTimer.Enabled = true;
        }
        private void ChangeCatCat(Object source, ElapsedEventArgs e)
        {
            CatImage = ResourceImage.GetImage("Images.Revit_Cat_Cat.jpg");
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        */
    }
}
