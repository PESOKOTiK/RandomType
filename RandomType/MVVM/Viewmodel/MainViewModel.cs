using RandomType.MVVM.Core;
using RandomType.MVVM.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using static RandomType.MVVM.Core.EnumToBool;



namespace RandomType.MVVM.Viewmodel
{
    public enum TypeMode
    {
        Time = 0,
        Words = 1
    }
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
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value;OnPropertyChanged(); }
        }
        private string hardlevel;
        public string HardLevel
        {
            get { return hardlevel; }
            set { hardlevel = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Words> ghostwords = new ObservableCollection<Words>();
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
        public RelayCommand MainCommand { get; set; }
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
        //settings commands and props
        public RelayCommand Settings1Command { get; set; }
        public RelayCommand Settings2Command { get; set; }
        public RelayCommand Settings3Command { get; set; }
        public RelayCommand Settings4Command { get; set; }
        private TypeMode _typeMode;
        public TypeMode Mode { get { return _typeMode; } set { _typeMode = value; OnPropertyChanged(); } }
        public MainViewModel()
        {
            Text = "";
            IsMaximized = false;
            CloseWindowCommand = new RelayCommand(f => App.Current.Shutdown());
            MaximizeWindowCommand = new RelayCommand(f => App.Current.MainWindow.WindowState = MinMaxWindow());
            MinimizeWindowCommand = new RelayCommand(f => App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized);
            DragMoveCommand = new RelayCommand(f => CanDragMove());
            MainCommand = new RelayCommand(f => Main());
            
            
        }
    

        public void Main()
        {
            ghostwords.Clear();
            using (StreamReader sr = new StreamReader("englishwords.txt"))
            {
                int hard = 0;
                string line;
                int.TryParse(hardlevel, out hard);
                if (hard > 3)
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line.Length == hard||line.Length==1)
                        {
                            ghostwords.Add(new Words(line, line.Length));
                        }
                    }
                }

            };
            StringBuilder sb = new();
            for (int i = 0; i < 30; i++)
            {
                Random r = new();
                int max = ghostwords.Count;
                if(max>0)
                    sb.Append(ghostwords.ElementAt(r.Next(0, max)));
                sb.Append(" ");
            }
            Text = sb.ToString();
        }
    }
}
