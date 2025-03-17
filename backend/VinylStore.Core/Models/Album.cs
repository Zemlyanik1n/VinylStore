using System.Drawing;
using CSharpFunctionalExtensions;

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
        if(albumName is null)
            return Result.Failure<Album>("Album name cannot be null");
        if(releaseType is null)
            return Result.Failure<Album>("Release type cannot be null");
        if (artistName is null)
            return Result.Failure<Album>("Artist name cannot be null");
        if (description is null)
            return Result.Failure<Album>("Description cannot be null");
        if(durationInSeconds <= 1)
            return Result.Failure<Album>("Duration cannot be less than 1");
        if(releaseYear < 1700)
            return Result.Failure<Album>("Release year cannot be less than 1700");
        if (tracks.Count == 0)
            return Result.Failure<Album>("Tracks cannot be empty");


        var album = new Album(albumName, releaseType, artistName, description, durationInSeconds, releaseYear, tracks);
        
        return Result.Success<Album>(album);
    }
}