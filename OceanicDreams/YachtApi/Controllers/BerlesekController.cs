
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YachtApi.Data;
using YachtApi.Models;

namespace YachtApi.Controllers
{
    [Route("api/berlesek")]
    [ApiController]
    public class BerlesekController : ControllerBase
    {
        private readonly YachtDbContext _context;

        public BerlesekController(YachtDbContext context)
        {
            _context = context;
        }

        // GET: api/berlesek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Berles>>> GetBerlesek()
        {
            return Ok(await _context.Berlesek.ToListAsync());
        }

        // GET: api/berlesek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Berles>> GetBerles(int id)
        {
            var berles = await _context.Berlesek.FindAsync(id);

            if (berles == null)
            {
                return NotFound("A megadott bérlés nem található.");
            }

            return Ok(berles);
        }

        // POST: api/berlesek
        [HttpPost]
        public async Task<ActionResult<Berles>> PostBerles(
            [FromBody] Berles berles)
        {
            // 1. Kezdőnap legalább holnap
            if (berles.StartDate.Date <= DateTime.Today)
            {
                return BadRequest(
                    "A bérlés kezdőnapja legkorábban holnap lehet.");
            }

            // 2-3. Bérlési időtartam ellenőrzése
            int napok =
                (berles.EndDate.Date - berles.StartDate.Date).Days + 1;

            if (napok < 5)
            {
                return BadRequest(
                    "A bérlés időtartama legalább 5 nap kell legyen.");
            }

            if (napok > 90)
            {
                return BadRequest(
                    "A bérlés időtartama legfeljebb 90 nap lehet.");
            }

            // 4. Átfedő foglalások ellenőrzése
            bool atfedes = await _context.Berlesek.AnyAsync(b =>
                b.YachtId == berles.YachtId &&
                b.StartDate <= berles.EndDate &&
                b.EndDate >= berles.StartDate);

            if (atfedes)
            {
                return BadRequest(
                    "Ez a yacht a megadott időszakban már foglalt.");
            }

            // Új bérlés mentése
            berles.Id = 0;

            _context.Berlesek.Add(berles);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBerles),
                new { id = berles.Id },
                berles);
        }

        // DELETE: api/berlesek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBerles(int id)
        {
            var berles = await _context.Berlesek.FindAsync(id);

            if (berles == null)
            {
                return NotFound("A megadott bérlés nem található.");
            }

            _context.Berlesek.Remove(berles);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
