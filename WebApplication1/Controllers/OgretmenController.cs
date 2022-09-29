using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class OgretmenController : Controller
    {
        Control ctrl= new Control();

        private readonly AppDBContext _db;
        public OgretmenController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            IEnumerable<Ogretmen> objOgretmenList = _db.Ogretmenler;
            return View(objOgretmenList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            var values = (from Ders in _db.Dersler
                          select Ders).ToList();
            ViewBag.v1 = new SelectList(values, "Id", "DersName");

            return View(new Ogretmen());
/*List<SelectListItem> value = (from Ders in _db.Dersler.ToList()
                                          select new SelectListItem
                                          {
                                              Text = Ders.DersName,
                                              Value = Ders.Id.ToString()
                                          }).ToList();
            ViewBag.v1 = value;*/

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ogretmen obj)
        {
            if (obj.OgretmenTc.Length != 11)
            {
                ModelState.AddModelError("", "11 karakterli numara giriniz");
            }
            else
            {
                var onay = ctrl.TcDogrula(obj.OgretmenTc);
                if(onay!=true)
                {
                    ModelState.AddModelError("", "Lütfen doğru bir TC kimlik numarası giriniz");
                }
            }

            if (ModelState.IsValid)
            {

                //obj.OgretmenBirthDate.ToString("dd/M/yyyy");
                //obj.OgretmenBirthDate = DateTime.Now;
                //obj.OgretmenBirthDate.ToShortDateString();

                _db.Ogretmenler.Add(obj);
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
            var ogretmenFromDb = _db.Ogretmenler.Find(id);
            if (ogretmenFromDb == null)
            {
                return NotFound();
            }
            return View(ogretmenFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ogretmen obj)
        {
            if (ModelState.IsValid)
            {
                _db.Ogretmenler.Update(obj);
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
            var ogretmenFromDb = _db.Ogretmenler.Find(id);
            if (ogretmenFromDb == null)
            {
                return NotFound();
            }
            return View(ogretmenFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Ogretmenler.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Ogretmenler.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        
    }
}
public class Control
{
    public bool TcDogrula(string x)
    {


        char[] chars;
        chars=x.ToCharArray();
        int[] arr1 = new int[11];
        int ten = 0;
        int eleven = 0;
        for (int i=0;i<x.Length;i++)
        {
            arr1[i] = Convert.ToInt32(chars[i].ToString());
        }

        ten = ((arr1[1] + arr1[3] + arr1[5] + arr1[7])*9+ ((arr1[0] + arr1[2] + arr1[4] + arr1[6] + arr1[8])*7))%10;

        
        eleven = (arr1[1] + arr1[2] + arr1[3] + arr1[4] + arr1[5] + arr1[6] + arr1[7] + arr1[8] + arr1[9]) % 10;

        if (ten == arr1[9]&&eleven == arr1[10])
        { return true; }

        return false;
    }
}
