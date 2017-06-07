using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamsungTest1.Controllers
{
    public class PlanesController : Controller
    {
        // GET: Planes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Planes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Planes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planes/Create
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

        // GET: Planes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Planes/Edit/5
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

        // GET: Planes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Planes/Delete/5
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
