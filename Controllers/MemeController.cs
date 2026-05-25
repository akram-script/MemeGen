using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class MemeController : ControllerBase
{
private readonly AppDbContext _context;
public MemeController(AppDbContext context)
{
_context = context;
}
[HttpGet]
public async Task<IActionResult> GetAll()
{
var memes = await _context.Memes
.OrderByDescending(x => x.CreatedAt)
.ToListAsync();
return Ok(memes);
}
[HttpPost]
public async Task<IActionResult> Create(Meme meme)
{
_context.Memes.Add(meme);
await _context.SaveChangesAsync();
return Ok(meme);
}
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
var meme = await _context.Memes.FindAsync(id);
if (meme == null)
return NotFound();
_context.Memes.Remove(meme);
await _context.SaveChangesAsync();
return NoContent();
}
}