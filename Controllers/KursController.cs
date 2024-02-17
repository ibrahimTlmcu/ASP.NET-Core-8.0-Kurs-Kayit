using KursKayir.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursKayir.Controllers
{
    public class KursController : Controller
    {

        private DataContext _context;

        public KursController(DataContext gelendata)
        {
            _context = gelendata;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Kurs model)
        {
            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Kurs");

        }

        public async Task<IActionResult> Index()
        {
            var kurslar = await _context.Kurslar.ToListAsync();
            return View(kurslar);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurs = await _context.Kurslar.FindAsync(id);
            //  var ogr = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.OgrenciKimlik == id);
            //Gelen id veritabainda bir karsiligi olmayabilir
            if (kurs == null)
            {
                return NotFound();
            }
            return View(kurs);
            //Bu bilgiler edit.cshtml icindeki modele gidecek
        }
    }
}
