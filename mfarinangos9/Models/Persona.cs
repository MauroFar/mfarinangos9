using SQLite;

namespace mfarinangos9.Models;

public class Persona
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
