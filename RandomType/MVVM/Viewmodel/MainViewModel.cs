using RandomType.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RandomType.MVVM.Viewmodel
{
    public class MainViewModel
    {
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get;set; }
        public RelayCommand MinimizeWindowCommand { get;set; }

        public WindowState MinMaxWindow()
        {
            if(App.Current.MainWindow.WindowState == System.Windows.WindowState.Maximized)
            {
                return System.Windows.WindowState.Normal;
            }
            else
            {
                return System.Windows.WindowState.Maximized;
            }
        }


        public MainViewModel()
        {
            CloseWindowCommand = new RelayCommand(o => App.Current.Shutdown());
            MaximizeWindowCommand = new RelayCommand(o=>App.Current.MainWindow.WindowState=MinMaxWindow());
            MinimizeWindowCommand = new RelayCommand(o => App.Current.MainWindow.WindowState=System.Windows.WindowState.Minimized);
        }
    }
}
