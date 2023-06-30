using RandomType.MVVM.Core;
using RandomType.MVVM.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;


namespace RandomType.MVVM.Viewmodel;
public class MainViewModel : ObservableObject
{
    private bool _isMaximized;
    private CustomTheme _selectedTheme;
    private string _text;
    private string _hardlevel;
    private TypeMode _typeMode;
    private readonly ObservableCollection<Words> _ghostWords;
    public MainViewModel()
    {
        Text = "";
        IsMaximized = false;
        CloseWindowCommand = new RelayCommand(f => Application.Current.Shutdown());
        MaximizeWindowCommand = new RelayCommand(f => Application.Current.MainWindow!.WindowState = MinMaxWindow());
        MinimizeWindowCommand = new RelayCommand(f => Application.Current.MainWindow!.WindowState = WindowState.Minimized);
        DragMoveCommand = new RelayCommand(f => CanDragMove());
        MainCommand = new RelayCommand(f => Render());
        _ghostWords = new ObservableCollection<Words>();
    }

    private void Render()
    {
        _ghostWords.Clear();
        AddGhostWords();
        RenderText();
    }

    private void RenderText()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < 30; i++)
        {
            Random r = new();
            var max = _ghostWords.Count;
            if (max > 0)
                sb.Append(_ghostWords.ElementAt(r.Next(0, max)));
            sb.Append(" ");
        }
        Text = sb.ToString();
    }

    private void AddGhostWords()
    {
        using var sr = new StreamReader("englishwords.txt");
        int.TryParse(_hardlevel, out var difficulty);
        if (difficulty <= 3) return;
        while (!sr.EndOfStream)
        {
            if (sr.ReadLine()!.Length == difficulty || sr.ReadLine()!.Length == 1)
            {
                _ghostWords.Add(new Words(sr.ReadLine(), sr.ReadLine()!.Length));
            }
        }
    }

    public ObservableCollection<Words> GhostWords => _ghostWords;
    public CustomTheme SelectedTheme
    {
        get => _selectedTheme;
        set
        {
            _selectedTheme = value;
            OnPropertyChanged();
        }
    }
    public string Text
    {
        get => _text;
        set {
            _text = value; 
            OnPropertyChanged();
        }
    }
    public string HardLevel
    {
        get => _hardlevel;
        set
        {
            _hardlevel = value;
            OnPropertyChanged();
        }
    }
    public bool IsMaximized
    {
        get => _isMaximized;
        set
        {
            _isMaximized = value;
            OnPropertyChanged();
        }
    }
    public void CanDragMove() { Application.Current.MainWindow!.DragMove(); }
    public TypeMode Mode
    {
        get => _typeMode;
        set
        {
            _typeMode = value;
            OnPropertyChanged();
        }
    }
    public WindowState MinMaxWindow()
    {
        if (Application.Current.MainWindow!.WindowState == WindowState.Maximized)
        {
            IsMaximized = false;
            return WindowState.Normal;
        }
        IsMaximized = true;
        return WindowState.Maximized;
    }

    public RelayCommand CloseWindowCommand { get; set; }
    public RelayCommand MaximizeWindowCommand { get; set; }
    public RelayCommand MinimizeWindowCommand { get; set; }
    public RelayCommand DragMoveCommand { get; set; }
    public RelayCommand MainCommand { get; set; }
    public RelayCommand Settings1Command { get; set; }
    public RelayCommand Settings2Command { get; set; }
    public RelayCommand Settings3Command { get; set; }
    public RelayCommand Settings4Command { get; set; }
}