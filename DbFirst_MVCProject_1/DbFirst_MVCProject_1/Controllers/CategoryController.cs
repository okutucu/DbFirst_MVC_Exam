using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbFirst_MVCProject_1.DesignPatterns.SingletonPattern;
using DbFirst_MVCProject_1.Models;
using DbFirst_MVCProject_1.ViewModels;

namespace DbFirst_MVCProject_1.Controllers
{
    public class CategoryController : Controller
    {
        NORTHWNDEntities _db;

        public CategoryController()
        {
            _db = DBTool.DbInstance;
        }

        // GET: Category
        public ActionResult ListCategories()
        {
            //return View(_db.Categories.ToList());
            //return View(Tuple.Create(_db.Categories.ToList(),_db.Products.ToList()));


            // View bu şekilde model göndermek çok yanlış birşeydir.
            // Open-Close prensibini bozar.
            // Bir sayfaya tek bir tablo gonderdik. Bir sayfaya 1 model gonderebileceğimizden tek bir tabloyu View'e gondermek anı kurtarabilir fakat genisletilebilir bir proje olmaz. (2 tablo ile calısmak istersek calisamayız..)

            // 2 veya daha fazla tablo ile calismak veya projeyi geliştirelebilir hale getirmek için ViewModeller yazarız.

            // Hangi controllerdeki hangi actionda çalışmak istiyorsek onun adında ViewModel açarız..


            // Doğru model gönderme yöntemi;
            
            CategoryVM cvm = new CategoryVM()
            {
                Categories =  _db.Categories.ToList(),
                Products = _db.Products.ToList(),
                Employees = _db.Employees.ToList()
            };

            // Boylelikle istediğimiz kadar tablo ekleyebiliriz.
            // CategoryVM classında veriyi enkapsüle ettikten sonra artık istediğimiz kadar property ekleyebiliriz.

            return View(cvm);
        }
    }
}