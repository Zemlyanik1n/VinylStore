using CSharpFunctionalExtensions;

namespace VinylStore.Core.Models;

public class Genre
{
    private Genre()
    {
    }

    private Genre(string name)
    {
        Name = name;
    }

    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static Result<Genre> Create(string? name)
    {
        if(name is null)
            return Result.Failure<Genre>("GenreName cannot be null");

        var genre = new Genre(name);

        return Result.Success<Genre>(genre);
    }
}