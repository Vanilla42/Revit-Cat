using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Revit_Cat
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private GameModel _gameModel;
        public GameViewModel()
        {
            _cells = new ObservableCollection<Cell>();
            _gameModel = new GameModel();
        }

        private bool[,] _isOpenedCells;
        public bool[,] IsOpenedCells
        {
            get { return _gameModel.IsOpened; }
            set
            {
                _isOpenedCells = value;
                OnPropertyChanged("IsOpenedCells");
            }
        }

        private ObservableCollection<Cell> _cells;
        public ObservableCollection<Cell> Cells
        {
            get { return _cells; }
            set { _cells = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
