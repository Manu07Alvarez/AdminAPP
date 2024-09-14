using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace administrationapp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isPaneOpen = true;

    [ObservableProperty]
    private ViewModelBase _CurrentPage = new HomePageViewModel();

    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
        new ListItemTemplate(typeof(HomePageViewModel))
     };
    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}

public class ListItemTemplate
{
    public ListItemTemplate ( Type type)
    {
        ModelType = type;
        label = type.Name.Replace("PageViewModel", "");
    }
    public string label { get; }
    public Type ModelType { get; }
}
