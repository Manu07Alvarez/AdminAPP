using System;
using Realms;

namespace administrationapp.Models;

public static class RiConfig
{
    private static RealmConfiguration? _configuration;

    // Inicializar la configuración de Realm solo una vez
    public static RealmConfiguration? GetConfiguration()
    {
        _configuration = new RealmConfiguration
        {
            SchemaVersion = 1,
            ShouldDeleteIfMigrationNeeded = true,
        };
        return _configuration;
    }

    // Método para obtener una instancia de Realm utilizando la configuración compartida

}