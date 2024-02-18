using Microsoft.AspNetCore.Mvc;
using KursKayir.Data;
using Microsoft.EntityFrameworkCore;

namespace KursKayir.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly DataContext _context;

        public OgrenciController(DataContext context)
        {
            _context = context;
        }
        //injection yontemi
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
            return View(ogrenciler);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var ogr = await _context.Ogrenciler.FindAsync(id);
          //  var ogr = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.OgrenciKimlik == id);
            //Gelen id veritabainda bir karsiligi olmayabilir
            if (ogr == null)
            {
                return NotFound();
            }
            return View(ogr);
            //Bu bilgiler edit.cshtml icindeki modele gidecek
        }
        [HttpPost]
        
        public async Task<IActionResult> Edit(int id , Ogrenci model)
        {
            if(id != model.OgrenciKimlik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ogrenciler.Any(o => o.OgrenciKimlik == model.OgrenciKimlik))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler.FindAsync(id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);

        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }


    }
}
