using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication8.Models;


namespace MvcApplication8.Controllers
{
    public class myController : Controller
    {
        //
        // GET: /my/
        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index()
        {
            return View("Index");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(ModelClass1 mc,string cmd)
        {
            string msg = mc.login();
            return Content("<script language='javascript'type='text/javascript'>alert('" + msg + "');</script>");
            //return View(mc);   
             
            
        }

    }
}
