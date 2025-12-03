using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Flowly.Api.Data;
using Flowly.Api.Models;

namespace Flowly.Api.Controllers;

[ApiController]
[Route("boards")]
[Authorize]
public class BoardsController : ControllerBase
{
    private readonly FlowlyDbContext _db;

    public BoardsController(FlowlyDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetMyBoards()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var userId)) return Unauthorized();

        var boards = await _db.Boards.Where(b => b.OwnerId == userId).ToListAsync();
        return Ok(boards);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBoard([FromBody] Board board)
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null) return Unauthorized();
        if (!int.TryParse(userIdClaim, out var userId)) return Unauthorized();
        board.OwnerId = userId;
        _db.Boards.Add(board);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMyBoards), new { id = board.BoardId }, board);
    }
}
