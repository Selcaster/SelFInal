using Musico.BL.Attributes;
using Musico.BL.DTOs;
using Musico.BL.Services;
using Musico.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Musico.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RecommendationController : ControllerBase
{
    private readonly IRecommendationService _recommendationService;

    public RecommendationController(IRecommendationService recommendationService)
    {
        _recommendationService = recommendationService;
    }

    [HttpGet("forUser/{userId}")]
    public async Task<ActionResult<IEnumerable<SongGetDto>>> GetRecommendationsForUser(int userId)
    {
        var recommendations = await _recommendationService.GetRecommendedSongsAsync(userId);
        return Ok(recommendations);
    }

}
