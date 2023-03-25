using BTVN_B5_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using BTVN_B5_4.Areas.Admin.Controllers;
using System.Data.SqlClient;

namespace BTVN_B5_4.Controllers
{
    public class Book_UserController : Controller
    {
        /*public PagedList.IPagedList<Book> Books { get; set; }*/
        private BookModelContext db = new BookModelContext();
        // GET: Book_User
        public ActionResult Index(string searchString, int? page)
        {
           
            if (page == null) page = 1;
            //var book = from l in db.Books select l;
             var links = (from l in db.Books select l).OrderBy(x => x.Id);
            //var links = (book).OrderBy(x => x.Id);
           int pageSize = 3;
            int pageNumber = (page ?? 1);
            /*var book_product = new BookModelContext();*/
           var  context = new BookModelContext();
            /*  if (!String.IsNullOrEmpty(searchString))
              {
                   book = book.Where(s => s.Title.ToLower().Contains(searchString)
                                        *//* || s.Author.Contains(searchString)*//*);
              }

              int pageSize = 3;
              int pageNumber = (page ?? 1);*/
            /*return View(book.ToPagedList(pageNumber, pageSize));*/

            /* switch (sortOrder)
             {
                 case "name_desc":
                     book = book.OrderByDescending(s => s.Title);
                     break;
                 case "Date":
                     book = book.OrderBy(s => s.Author);
                     break;*/
            /* case "date_desc":
                 book = book.OrderByDescending(s => s);
                 break;
             default:  // Name ascending 
                 book = book.OrderBy(s => s.LastName);
                 break;*/
            //}

            return View(context.Books.ToList().ToPagedList(pageNumber, pageSize));
            //return View(book.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult Search(string searchString, int? page)
        {
            /*using(BookModelContext db = new BookModelContext())
                {*/
               //var context = db.Books.Where(p => p.Title.ToLower().Contains(searchString)).ToList();
            if (page == null) page = 1;
            //var links = (from l in db.Books select l).OrderBy(x => x.Id);
            var links = (from l in db.Books where l.Title.ToLower().Contains(searchString) select l);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View("Index", links.ToPagedList(pageNumber, pageSize));
           // }
            

            /*  if (!String.IsNullOrEmpty(searchString))
              {
                  var product = new BookModelContext();
                   return View(product.Books.ToList().ToPagedList(pageNumber, pageSize));
              }*/

            /*var context = new BookModelContext().Books.Where(p => p.Title.ToLower().ToPagedList(searchString));*/
            
        }

        /* public List<Book> Search(string searchString)
         {
             return db.Books.SqlQuery("select * from Book where Title like '%" + searchString+"%'").ToList();
         }*/

        public ActionResult GetBookByCategory(int id)
        {
            var context = new BookModelContext();
            return View("Index", context.Books.Where(p => p.CategoryId == id).ToList());
        }

        public ActionResult GetCategory(int id)
        {
            var context = new BookModelContext();
            var listCategory = context.Categories.ToList();
            return PartialView(listCategory);
        }

        public ActionResult Detail(int id)
        {
            var context = new BookModelContext();
            var firstbook = context.Books.FirstOrDefault(p => p.Id == id);

            if (firstbook == null)
            {
                return HttpNotFound("Cann't Find ID Book");
            }
            return View(firstbook);
        }

        public ActionResult AddToCart(int id)
        {
            try
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
            catch (Exception ex)
            {
                return Content("Success Adding");
            }
        }
    }
}