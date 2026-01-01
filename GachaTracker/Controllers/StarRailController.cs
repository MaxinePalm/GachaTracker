using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GachaTracker.Data;
using GachaTracker.Models;

namespace GachaTracker.Controllers
{
    public class StarRailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StarRailController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var characters = await _context.StarRailCharacters.ToListAsync();
            return View(characters);
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var characters = await _context.StarRailCharacters.ToListAsync();
            return Json(characters);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Element,Path,Rarity,CurrentLevel,LightconeName,LightconeLevel,TalentBasicAttack,TalentSkill,TalentUltimate,TalentTalent,RelicSet,RelicPieces")] StarRailCharacter character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Element,Path,Rarity,CurrentLevel,LightconeName,LightconeLevel,TalentBasicAttack,TalentSkill,TalentUltimate,TalentTalent,RelicSet,RelicPieces")] StarRailCharacter character)
        {
            if (id != character.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.StarRailCharacters.AnyAsync(e => e.Id == character.Id))
                        return NotFound();
                    else
                        throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.StarRailCharacters.FindAsync(id);
            if (character != null)
            {
                _context.StarRailCharacters.Remove(character);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}