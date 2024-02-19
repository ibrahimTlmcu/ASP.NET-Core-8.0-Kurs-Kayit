using KursKayir.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KursKayir.Controllers
{
    public class KursKayıtController : Controller
    {
        private readonly DataContext _dataContext;

        public KursKayıtController(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var kurskayitlari = await _dataContext.KursKayitlari
                .Include(x => x.Ogrenci)
                .Include(x =>x.Kurs).ToListAsync();
            return View(kurskayitlari); 
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _dataContext.Ogrenciler.ToListAsync(),"OgrenciKimlik","AdSoyad");
            ViewBag.Kurslar = new SelectList(await _dataContext.Kurslar.ToListAsync(), "KursID", "KursBaslik");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(KursKayit model)
        {
            model.KayitTarihi = DateTime.Now;  
            _dataContext.KursKayitlari.Add(model);
            await _dataContext.SaveChangesAsync();
           
            return RedirectToAction("Index");   
        }


    }
}
