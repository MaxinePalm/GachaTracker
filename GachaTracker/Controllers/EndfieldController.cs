using GachaTracker.Data;
using GachaTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GachaTracker.Controllers
{
    public class EndfieldController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EndfieldController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Endfield
        public async Task<IActionResult> Index()
        {
            var characters = await _context.EndfieldCharacters.ToListAsync();
            return View(characters);
        }

        // POST: Endfield/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ElementType,SubClass,WeaponType,CharacterLevel,WeaponLevel," +
            "TrustTalent1,TrustTalent2,TrustTalent3,TrustTalent4," +
            "UnderTrustTalent1,UnderTrustTalent2,UnderTrustTalent3,UnderTrustTalent4," +
            "ShipTalent1,ShipTalent2,ShipTalent3,ShipTalent4," +
            "PromotionLevel,OutfittingLevel," +
            "MainTalent1,MainTalent2,MainTalent3,MainTalent4")] EndfieldCharacter character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", await _context.EndfieldCharacters.ToListAsync());
        }

        // POST: Endfield/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ElementType,SubClass,WeaponType,CharacterLevel,WeaponLevel," +
            "TrustTalent1,TrustTalent2,TrustTalent3,TrustTalent4," +
            "UnderTrustTalent1,UnderTrustTalent2,UnderTrustTalent3,UnderTrustTalent4," +
            "ShipTalent1,ShipTalent2,ShipTalent3,ShipTalent4," +
            "PromotionLevel,OutfittingLevel," +
            "MainTalent1,MainTalent2,MainTalent3,MainTalent4")] EndfieldCharacter character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EndfieldCharacterExists(character.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View("Index", await _context.EndfieldCharacters.ToListAsync());
        }

        // POST: Endfield/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var character = await _context.EndfieldCharacters.FindAsync(id);
            if (character != null)
            {
                _context.EndfieldCharacters.Remove(character);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EndfieldCharacterExists(int id)
        {
            return _context.EndfieldCharacters.Any(e => e.Id == id);
        }
    }
}