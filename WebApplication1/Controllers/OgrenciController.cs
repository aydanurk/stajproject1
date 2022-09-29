using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OgrenciController : Controller
    {
        Control ctrl = new Control();
        private readonly AppDBContext _db;
        public OgrenciController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Ogrenci> objOgrenciList = _db.Ogrenciler;
            return View(objOgrenciList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            /*List<SelectListItem> values = (from Ogretmen in _db.Ogretmenler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = Ogretmen.OgretmenName,
                                               Value = Ogretmen.Id.ToString()
                                           }).ToList();
            ViewBag.v1 = values;*/
            var values = (from Ogretmen in _db.Ogretmenler
                          select Ogretmen).ToList();
            ViewBag.v1 = new SelectList(values, "Id", "OgretmenName");

            return View(new Ogrenci());

        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ogrenci obj)
        {
            if (obj.OgrenciTc.Length != 11)
            {
                ModelState.AddModelError("", "11 karakterli numara giriniz");
            }
            else
            {
                var onay = ctrl.TcDogrula(obj.OgrenciTc);
                if (onay != true)
                {
                    ModelState.AddModelError("", "Lütfen doğru bir TC kimlik numarası giriniz");
                }
            }

            if (ModelState.IsValid)
            {
                //obj.OgrenciBirthDate.ToShortDateString();
                _db.Ogrenciler.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(obj);
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ogrenciFromDb = _db.Ogrenciler.Find(id);
            if (ogrenciFromDb == null)
            {
                return NotFound();
            }
            return View(ogrenciFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ogrenci obj)
        {
            if (ModelState.IsValid)
            {
                _db.Ogrenciler.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ogrenciFromDb = _db.Ogrenciler.Find(id);
            if (ogrenciFromDb == null)
            {
                return NotFound();
            }
            return View(ogrenciFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Ogrenciler.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Ogrenciler.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
public class Control2
{
    public bool TcDogrula(string x)
    {


        char[] chars;
        chars = x.ToCharArray();
        int[] arr1 = new int[11];
        int ten = 0;
        int eleven = 0;
        for (int i = 0; i < x.Length; i++)
        {
            arr1[i] = Convert.ToInt32(chars[i].ToString());
        }

        ten = ((arr1[1] + arr1[3] + arr1[5] + arr1[7]) * 9 + ((arr1[0] + arr1[2] + arr1[4] + arr1[6] + arr1[8]) * 7)) % 10;


        eleven = (arr1[1] + arr1[2] + arr1[3] + arr1[4] + arr1[5] + arr1[6] + arr1[7] + arr1[8] + arr1[9]) % 10;

        if (ten == arr1[9] && eleven == arr1[10])
        { return true; }

        return false;
    }
}
