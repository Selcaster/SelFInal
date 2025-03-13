using Musico.BL.Attributes;
using Musico.BL.DTOs;
using Musico.BL.Helpers;
using Musico.BL.Services;
using Musico.Core.Entities;
using Musico.DAL.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Musico.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet("songs")]
    public async Task<ActionResult<IEnumerable<SongGetDto>>> SearchSongs([FromQuery] string query)
    {
        var songs = await _searchService.SearchSongsAsync(query);
        return Ok(songs);
    }

    [HttpGet("artists")]
    public async Task<ActionResult<IEnumerable<ArtistGetDto>>> SearchArtists([FromQuery] string query)
    {
        var artists = await _searchService.SearchArtistsAsync(query);
        return Ok(artists);
    }

    [HttpGet("playlists")]
    public async Task<ActionResult<IEnumerable<PlaylistGetDto>>> SearchPlaylists([FromQuery] string query)
    {
        var playlists = await _searchService.SearchPlaylistsAsync(query);
        return Ok(playlists);
    }
}
