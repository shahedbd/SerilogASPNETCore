using DBRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogASPNETCoreFileSinks.Controllers
{
    public class BasicInfoesController : Controller
    {
        private readonly DataBaseContext _context;
        public BasicInfoesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: BasicInfoes
        public async Task<IActionResult> Index()
        {
            Log.Logger.ForContext("OtherData", "This data for OtherData column").Information("BasicInfo Index has been called successfully");
            return View(await _context.BasicInfo.ToListAsync());
        }

        // GET: BasicInfoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicInfo = await _context.BasicInfo
                .FirstOrDefaultAsync(m => m.BasicInfoID == id);
            if (basicInfo == null)
            {
                return NotFound();
            }

            return View(basicInfo);
        }

        // GET: BasicInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BasicInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasicInfoID,FirstName,LastName,DateOfBirth,City,Country,MobileNo,NID,Email,Status")] BasicInfo basicInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basicInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basicInfo);
        }

        // GET: BasicInfoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicInfo = await _context.BasicInfo.FindAsync(id);
            if (basicInfo == null)
            {
                return NotFound();
            }
            return View(basicInfo);
        }

        // POST: BasicInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BasicInfoID,FirstName,LastName,DateOfBirth,City,Country,MobileNo,NID,Email,Status")] BasicInfo basicInfo)
        {
            if (id != basicInfo.BasicInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basicInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicInfoExists(basicInfo.BasicInfoID))
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
            return View(basicInfo);
        }

        // GET: BasicInfoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicInfo = await _context.BasicInfo
                .FirstOrDefaultAsync(m => m.BasicInfoID == id);
            if (basicInfo == null)
            {
                return NotFound();
            }

            return View(basicInfo);
        }

        // POST: BasicInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var basicInfo = await _context.BasicInfo.FindAsync(id);
            _context.BasicInfo.Remove(basicInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicInfoExists(long id)
        {
            return _context.BasicInfo.Any(e => e.BasicInfoID == id);
        }
    }
}
