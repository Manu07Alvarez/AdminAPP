using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using ReactiveUI;


namespace administrationapp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isPaneOpen = true;

    [ObservableProperty]
    private object? _currentPage = new HomePageViewModel();

    [ObservableProperty]
    private ListItemTemplate? _selectedListItem;
    
    private static readonly object[] InstanceArray = {
        new HomePageViewModel(),
        new StockPageViewModel(),
        new ButtonPageViewModel()
    };
    

    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;
        CurrentPage = value.ViewInstance;
    }
    public ObservableCollection<ListItemTemplate> Items { get; } =
    [
        new(typeof(HomePageViewModel), "Homeregular", InstanceArray[0]),
        new(typeof(StockPageViewModel), "app_generic_regular", InstanceArray[1]),
        new(typeof(ButtonPageViewModel), "CursorHoverRegular", InstanceArray[2])
    ];
    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}

public class ListItemTemplate
{
    public ListItemTemplate(Type type, string iconKey,object instance)
    {
        ViewInstance =  instance;
        ModelType = type;
        Label = type.Name.Replace("PageViewModel", "");
        Application.Current!.TryFindResource(iconKey, out var res);
        ListItemIcon = (StreamGeometry)res!;

    }
    public string Label { get; }
    public object ViewInstance { get; }
    public Type ModelType { get; }
    public StreamGeometry ListItemIcon { get; }
}
