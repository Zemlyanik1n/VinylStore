using CSharpFunctionalExtensions;

namespace VinylStore.Core.Models;

public class Track
{
    private Track()
    {
    }

    private Track(string name, int durationInSeconds, int position)
    {
        Name = name;
        DurationInSeconds = durationInSeconds;
        Position = position;
    }

    public long Id { get; set; }
    public int DurationInSeconds { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int Position { get; set; } = 0;
    public long AlbumId { get; set; }
    public Album Album { get; set; }

    public static Result<Track> Create(string? name, int durationInSeconds, int position)
    {
        if(name is null)
            return Result.Failure<Track>("Name cannot be null");
        if (position < 1)
            return Result.Failure<Track>("Position cannot be less than 1");
        if (durationInSeconds < 1)
            return Result.Failure<Track>("Duration cannot be less than 1");

        var track = new Track(name, durationInSeconds, position);
        
        return Result.Success(track);
    }
}