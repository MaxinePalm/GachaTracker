using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GachaTracker.Data;
using GachaTracker.Models;

namespace GachaTracker.Controllers
{
    public class WutheringController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WutheringController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var characters = await _context.WutheringCharacters.ToListAsync();
            return View(characters);
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var characters = await _context.WutheringCharacters.ToListAsync();
            return Json(characters);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Element,Rarity,CurrentLevel,WeaponType,WeaponName,WeaponLevel,SkillNormalAttack,SkillResonanceSkill,SkillForteCircuit,SkillResonanceLiberation,SkillIntroSkill,StatNodesCompleted,InherentSkillsCompleted,EchoSet,EchoPieces")] WutheringCharacter character)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Element,Rarity,CurrentLevel,WeaponType,WeaponName,WeaponLevel,SkillNormalAttack,SkillResonanceSkill,SkillForteCircuit,SkillResonanceLiberation,SkillIntroSkill,StatNodesCompleted,InherentSkillsCompleted,EchoSet,EchoPieces")] WutheringCharacter character)
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
                    if (!await _context.WutheringCharacters.AnyAsync(e => e.Id == character.Id))
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
            var character = await _context.WutheringCharacters.FindAsync(id);
            if (character != null)
            {
                _context.WutheringCharacters.Remove(character);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}