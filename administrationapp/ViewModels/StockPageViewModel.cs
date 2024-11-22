
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Input;
using ReactiveUI;
using administrationapp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Realms;
using System.Threading.Tasks;

namespace administrationapp.ViewModels;

public partial class StockPageViewModel : ViewModelBase
{

    private readonly Realm _realm = Realm.GetInstance(RiConfig.GetConfiguration());
    
    [ObservableProperty]
    private IEnumerable<CellObject>? _list;

    [RelayCommand]
    private void DeleteObjcts()
    {
        _realm.Write(() => _realm.RemoveAll());

    }
    
    [RelayCommand]
    private async Task LoadData()
    {
        await SpreadsheetImportModel.ReadSpreedSheet("/home/manu/Escritorio/test1.ods");
        List = _realm.All<CellObject>();

    }
}

