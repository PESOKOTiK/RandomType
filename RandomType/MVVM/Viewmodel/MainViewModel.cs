using RandomType.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomType.MVVM.Viewmodel
{
    public class MainViewModel
    {
        public RelayCommand CloseWindowCommand { get; set; }


        public MainViewModel()
        {
            CloseWindowCommand = new RelayCommand(o => App.Current.Shutdown());
        }
    }
}
