using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
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

    [ObservableProperty]
    private ListItemTemplate? _SelectedListItem;

    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;
        var instance=Activator.CreateInstance(value.ModelType);
        if (instance is null) return;
        CurrentPage = (ViewModelBase)instance;
    }
    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
        new ListItemTemplate(typeof(HomePageViewModel),"Homeregular"),
        new ListItemTemplate(typeof(ButtonPageViewModel), "CursorHoverRegular"),
     };
    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}

public class ListItemTemplate
{
    public ListItemTemplate ( Type type, string IconKey)
    {
        ModelType = type;
        label = type.Name.Replace("PageViewModel", "");

        Application.Current!.TryFindResource(IconKey, out var res);
        ListItemIcon = (StreamGeometry)res!;

    }
    public string label { get; }
    public Type ModelType { get; }
    public StreamGeometry ListItemIcon { get; }
}
