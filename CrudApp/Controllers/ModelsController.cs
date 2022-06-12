using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    public class ModelsController : Controller
    {
        private readonly ApplicationContext _context;

        public ModelsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Models
        public async Task<IActionResult> Index(string SearchText = "")
        {
            var result = await _context.Models.Where(m => !m.IsDeleted && !m.IsEdited).ToListAsync();

            if (!string.IsNullOrEmpty(SearchText))
            {
                result = result.Where(x => 
                    x.Name.ToLower().Contains(SearchText.ToLower()) ||
                    //x.Name.ToLower().Contains(SearchText.ToLower()) ||
                    x.FirstName.ToLower().Contains(SearchText.ToLower())
                    ).ToList();
            }

            return View(result);
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Model());
            }
            else
            {
                return View(_context.Models.Find(id));
            }
            
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,FirstName")] Model model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _context.Add(model);
                    var histo = new History
                    {
                        Id = 0,
                        ActionId = 1,
                        UserId = 1,
                        NewEntity = model,
                        ActionDate = DateTime.Now,
                    };
                    _context.Histories.Add(histo);
                }
                else
                {
                    var oldModel = await _context.Models
                        .FirstOrDefaultAsync(m => m.Id == model.Id);
                    if (oldModel == null)
                    {
                        return NotFound();
                    }

                    oldModel.IsEdited = true;
                    _context.Update(oldModel);

                    var newModel = new Model
                    {
                        Id = 0,
                        FirstName = model.FirstName,
                        Name = model.Name,
                         IsDeleted = false,
                         IsEdited = false,
                    };

                    _context.Add(newModel);

                    var histo = new History
                    {
                        Id = 0,
                        ActionId = 2,
                        UserId = 1,
                        OldEntity = oldModel,
                        NewEntity = newModel,
                        ActionDate = DateTime.Now,
                    };
                    _context.Histories.Add(histo);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            model.IsDeleted = true;
            _context.Models.Update(model);
            var histo = new History
            {
                Id = 0,
                ActionId = 3,
                UserId = 1,
                OldEntityId = model.Id,
                ActionDate = DateTime.Now,
            };
            _context.Histories.Add(histo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
