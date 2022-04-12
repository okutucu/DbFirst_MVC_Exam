using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbFirst_MVCProject.DesignPatterns.SingletonPattern;
using DbFirst_MVCProject.Models;

namespace DbFirst_MVCProject.Controllers
{
    public class CategoryController : Controller
    {
        // Category işlemlerini yapacak olan CategoryController sınıfını olusturduk.

        NORTHWNDEntities _db;

        //CategoryController calıstıgı zaman ilk olarak constructor calisacagindan NORTHWNDEntities tipindeki db değişkenin DBTool.DBInstance kapsullenmis static propertysine ulastık. Bu method sayesinde biz bu controllerı kaç kere calıstırırsak calıstıralım database instancesi bir kere olusturulacak.
        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }
        //Controller içindeki methodlar Action olarak adlandırılır.
        // BringCategories  (Attributesi yoksa Default olarak GET)  methodu bize _db.Categories modelini liste halinde göndürüp View'e gonderir.
        // View (Front-End) tarafında bu değer karsilanmalidir.
        public ActionResult BringCategories()
        {
            return View(_db.Categories.ToList());
        }

        // Ekleme işlemi yapabilmemiz için ilk önce front ende boş bir form veya post edilmesi gereken bir içerik yollamıyız ki geriye o get üzerinden post işlemi alabilelim.
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        //AddCategory(Category item) parametre almasının sebebi ise post işlemi olacağından bu sefer backend tarafı değilde frontent tarafı bir model gonderecek. 
        public ActionResult AddCategory(Category item)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();

            //  return View(); yazarsak View'da argüman olmadığı için ActionResult AddCategorynin get işlemini getireceğinden yeniden AddCategory'in get actionuna gider

            // return View("BringCategories"); View içine string yazdıgımızda biz model yerine view gondermiş oluruz. BringCategories View'i model (Frontend kısmına @model ... yazdığımızdan) beklediği için sağlıklı bir işlem olmaz.

            return redirecttoaction("bringcategories");

            // Ekleme işlemi yaptıktan sonra BringCategories isimli actiona yonlendirme yaptık. CUnku BringCategories Action listeleme işi yaptığı için. (Sayfalar action sayesinde çalıştığı için.)

        }
    }
}