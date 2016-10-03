using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISay.Models;
using System.IO;
using System.Text;
using MvcPaging;

namespace ISay.Controllers
{
    public class BlogsController : Controller
    {
        private ISayEntities db = new ISayEntities();

        // 分頁後每頁顯示的筆數
        int defaultPageSize = 3;

        // GET: Blogs
        public ActionResult Index(string tag, int? page)
        {
            if (tag.Equals("BossSay") || tag.Equals("Travel"))
            {
                ViewBag.PostType = tag;
                ViewBag.Title = tag == "BossSay" ? "Boss Says" : tag;
                ViewBag.CssType = tag == "BossSay" ? "bs_bg" : "travel_bg";

                var blogs = db.Blogs
                    .Where(m => m.display == true && m.post_type == tag)
                    .OrderBy(m => m.sort == null ? "99" : m.sort)
                    .ThenByDescending(m => m.create_date).ToList();

                // 計算出目前要顯示第幾頁的資料 ( 因為 page 為 Nullable<int> 型別 )
                int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

                return View(blogs.ToPagedList(currentPageIndex, defaultPageSize));
            }
            else
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id, string tag)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);

            if (blog == null)
            {
                return HttpNotFound();
            }

            ViewBag.PostType = tag;

            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                PostType pt = new PostType();
                ViewBag.pt = pt.returnList();

                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Account", new { id = "loginLink" });
            }
        }

        // POST: Blogs/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "seqno,title,subtitle,detail,post_type,create_date")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                //Not Use
                //Use CommonMark.NET (Markdown To HTML)
                //parseStr += CommonMark.CommonMarkConverter.Convert(str);

                //Change identity ID
                int max_seqno = db.Blogs.Count() + 1;
                blog.seqno = int.Parse(blog.create_date.ToString("yyyyMMdd") + max_seqno.ToString());

                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
