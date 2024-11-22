using Realms;

namespace administrationapp.Models;

public class CellObject : RealmObject
{
    [PrimaryKey]
    public string Id { get; set; } 
    public string Nombre { get; set; } 
    public string Cantidad { get; set; } 
}