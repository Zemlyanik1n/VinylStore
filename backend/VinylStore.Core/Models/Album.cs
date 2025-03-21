using System.Drawing;
using CSharpFunctionalExtensions;
using VinylStore.Core.Enums;

namespace VinylStore.Core.Models;

public class Album
{
    private Album()
    {
    }

    private Album(string albumName, string releaseType, string artistName, string description,
        int durationInSeconds, int releaseYear, ICollection<Track> tracks)
    {
        AlbumName = albumName;
        ReleaseType = releaseType;
        ArtistName = artistName;
        Description = description;
        Duration = durationInSeconds;
        ReleaseYear = releaseYear;
        Tracks = tracks;
    }

    public long Id { get; set; }
    public string AlbumName { get; set; }
    public string ReleaseType { get; set; }
    public string ArtistName { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; } = 0;
    public int ReleaseYear { get; set; } = 0;
    public ICollection<Genre> Genres { get; set; } = [];
    public ICollection<Track> Tracks { get; set; } = [];
    public ICollection<VinylPlate>? VinylPlates { get; set; }

    public static Result<Album> Create(string? albumName, string? releaseType, string? artistName, string? description,
        int durationInSeconds, int releaseYear, ICollection<Track> tracks)
    {
        if(string.IsNullOrEmpty(albumName))
            return Result.Failure<Album>("Album name cannot be null");
        if(string.IsNullOrEmpty(releaseType) || (releaseType != "Single" && releaseType != "LP" && releaseType != "EP"))
            return Result.Failure<Album>("Release type is invalid");
        if (string.IsNullOrEmpty(artistName))
            return Result.Failure<Album>("Artist name cannot be null");
        if (string.IsNullOrEmpty(description))
            return Result.Failure<Album>("Description cannot be null");
        if(durationInSeconds <= 1)
            return Result.Failure<Album>("Duration cannot be less than 1");
        if(releaseYear < 1700 || releaseYear > DateTime.Now.Year)
            return Result.Failure<Album>("Release year is out of range");
        if (tracks.Count == 0)
            return Result.Failure<Album>("Tracks cannot be empty");

        var pos = 1;
        var tracksToAdd = tracks.OrderBy(t => t.Position);
        foreach (var track in tracksToAdd)
        {
            if(track.Position != pos)
                return Result.Failure<Album>("Track positions is not valid");
            pos++;
        }

        var album = new Album(albumName, releaseType, artistName, description, durationInSeconds, releaseYear, tracks);
        
        return Result.Success<Album>(album);
    }
}