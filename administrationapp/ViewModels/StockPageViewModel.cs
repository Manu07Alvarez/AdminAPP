using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using ReactiveUI;
using administrationapp.Models;

namespace administrationapp.ViewModels;

public class StockPageViewModel : ViewReactiveModelBase
{
    private readonly SpreadsheetImportModel _spreadsheetImportModel;
    
    private ObservableCollection<SpreadsheetImportModel.SpreadsheetData> _excelData;

    public ObservableCollection<SpreadsheetImportModel.SpreadsheetData> ExcelData
    {
        get => _excelData;
        set => this.RaiseAndSetIfChanged(ref _excelData, value);
    }

    public ICommand LoadDataCommand { get; }
    
    public StockPageViewModel()
    {
        _spreadsheetImportModel = new SpreadsheetImportModel();

        // Inicializar la colección vacía
        ExcelData = new ObservableCollection<SpreadsheetImportModel.SpreadsheetData>();

        // Inicializar el comando para cargar los datos
        LoadDataCommand = ReactiveCommand.Create(LoadData);
                        
        Debug.WriteLine("A2");
        
    }
    
    private void LoadData()
    {
        _ = SpreadsheetImportModel.ReadExcelFile("/home/manu/Escritorio/test1.ods");
    }
}