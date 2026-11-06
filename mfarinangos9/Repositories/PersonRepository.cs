using SQLite;
using mfarinangos9.Models;

namespace mfarinangos9.Repositories;

public class PersonRepository
{
    private readonly SQLiteConnection _connection;

    public string StatusMessage { get; private set; } = string.Empty;

    public PersonRepository(string databasePath)
    {
        _connection = new SQLiteConnection(databasePath);
        _connection.CreateTable<Persona>();
    }

    public void AddNewPerson(string name)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                StatusMessage = "Escribe un nombre.";
                return;
            }

            _connection.Insert(new Persona { Name = name.Trim() });
            StatusMessage = "Persona guardada correctamente.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public List<Persona> GetAllPerson()
    {
        try
        {
            StatusMessage = string.Empty;
            return _connection.Table<Persona>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
            return new List<Persona>();
        }
    }

    public void DeletePerson(int id)
    {
        try
        {
            Persona? person = _connection.Find<Persona>(id);

            if (person == null)
            {
                StatusMessage = "No se encontró la persona.";
                return;
            }

            _connection.Delete(person);
            StatusMessage = "Persona eliminada correctamente.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
}
