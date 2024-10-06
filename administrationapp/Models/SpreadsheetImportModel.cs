using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using SPSReader;

namespace administrationapp.Models;

public static class SpreadsheetImportModel
{
    public static async Task ReadSpreedSheet(string filePath)
    {
      var cellDic = await XlReader.Reader(filePath);
      using var realm = await Realm.GetInstanceAsync(RiConfig.GetConfiguration());
      cellDic.RemoveAt(0);
      foreach (var rowCell in cellDic.SkipLast(1))
      {
          await realm.WriteAsync(() => realm.Add(new CellObject
          {
              Id = rowCell["Cell_1"], // O algún identificador único que prefieras
              Nombre = rowCell["Cell_2"],
              Cantidad = rowCell["Cell_3"]
          }, update:true));
      } // Retorna la lista de diccionarios con las celdas y valores.
    }
}

