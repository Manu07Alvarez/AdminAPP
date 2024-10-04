using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SPSReader;

namespace administrationapp.Models;

public class SpreadsheetImportModel
{
    public static async Task<List<SpreadsheetData>> ReadExcelFile(string filePath)
    {
      var Dic = await XlReader.Reader(filePath);
      var data = new List<SpreadsheetData>();
      foreach (var dic in Dic)
      {
        Console.WriteLine(dic["Cell_1"]);
      }

      return data;
    }
    
    public class SpreadsheetData
    {
        public string Codigo { get; set; } // Esta podría ser la primera columna
        public string Nombre { get; set; } // Esta podría ser la segunda columna
        public int Cantidad { get; set; }  // Esta podría ser la tercera columna
    }
}

