using ISay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISay.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ErrorPage()
        {
            ViewBag.Title = "404";

            ErrMsg errmsg = new ErrMsg();
            List<string> ErrMsg_CN = errmsg.returnList_CN();
            List<string> ErrMsg_EN = errmsg.returnList_EN();

            Random rNum = new Random();
            string rErrMsg_CN = ErrMsg_CN[rNum.Next(ErrMsg_CN.Count)];
            string rErrMsg_EN = ErrMsg_EN[rNum.Next(ErrMsg_EN.Count)];

            ViewBag.ErrMsg_CN = rErrMsg_CN;
            ViewBag.ErrMsg_EN = rErrMsg_EN;

            return View();
        }
    }
}