﻿namespace Musico.Core.Entities;
public class User:BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public List<LikedSong> LikedSongs { get; set; } = new();
    public List<Playlist> Playlists { get; set; } = new();
}