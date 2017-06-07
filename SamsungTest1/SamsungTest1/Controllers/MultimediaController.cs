using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamsungTest1.Controllers
{
    public class MultimediaController : Controller
    {
        // GET: Multimedia
        public ActionResult Index()
        {
            return View();
        }

        // GET: Multimedia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Multimedia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Multimedia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Multimedia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Multimedia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Multimedia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Multimedia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
