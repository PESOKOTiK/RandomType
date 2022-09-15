using RandomType.MVVM.Core;
using RandomType.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RandomType.MVVM.Viewmodel
{
    public class MainViewModel:ObservableObject
    {
        public bool isMaximized;
        private CustomTheme selectedTheme;

        public CustomTheme SelectedTheme
        {
            get { return selectedTheme; }
            set { selectedTheme = value;
                OnPropertyChanged(); }
        }

        public bool IsMaximized
        {
            get => isMaximized;
            set
            {
                isMaximized = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get;set; }
        public RelayCommand MinimizeWindowCommand { get;set; }
        public RelayCommand DragMoveCommand { get; set; }
        public WindowState MinMaxWindow()
        {
            if(App.Current.MainWindow.WindowState == System.Windows.WindowState.Maximized)
            {
                IsMaximized = false;
                return System.Windows.WindowState.Normal;

            }
            else
            {
                IsMaximized = true;
                return System.Windows.WindowState.Maximized;
            }
        }
        public void CanDragMove(){ App.Current.MainWindow.DragMove(); }
        public MainViewModel()
        {
            IsMaximized=false;
            CloseWindowCommand = new RelayCommand(o => App.Current.Shutdown());
            MaximizeWindowCommand = new RelayCommand(o=>App.Current.MainWindow.WindowState=MinMaxWindow());
            MinimizeWindowCommand = new RelayCommand(o => App.Current.MainWindow.WindowState=System.Windows.WindowState.Minimized);
            DragMoveCommand = new RelayCommand(o => CanDragMove());
        }
    }
}
