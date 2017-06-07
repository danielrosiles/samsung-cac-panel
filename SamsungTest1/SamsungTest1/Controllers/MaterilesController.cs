using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamsungTest1.Controllers
{
    public class MaterilesController : Controller
    {
        // GET: Materiles
        public ActionResult Index()
        {
            return View();
        }

        // GET: Materiles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Materiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materiles/Create
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

        // GET: Materiles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Materiles/Edit/5
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

        // GET: Materiles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Materiles/Delete/5
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
