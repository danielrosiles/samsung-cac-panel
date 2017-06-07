using SamsungTest1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamsungTest1.Controllers
{
    public class BannerController : Controller
    {
        hyperiondg_samsung_sales_forceEntities entidad = new hyperiondg_samsung_sales_forceEntities();
        // GET: Banner
        public ActionResult Index()
        {
            var listadoClientes = entidad.banner;
            return View(listadoClientes.ToList());
        }

        // GET: Banner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Banner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
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

        // GET: Banner/Edit/5
        public ActionResult Edit(int id)
        {
            TempData["id"] = id;
            return View();
        }

        // POST: Banner/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase UploadBanner, int id)
        {
            string banner_path = "";
            if (UploadBanner != null && UploadBanner.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(UploadBanner.FileName);
                string newpath = Server.MapPath("~/Content/Resources/banners/");
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                UploadBanner.SaveAs(path);
                banner_path = UploadBanner.FileName;
            }

            string _connStr = GetConnectionString();

            string _query = "UPDATE[hyper_hyperiondg].[banner]" +
                            "SET [banner]='" + banner_path + "'" +
                            "WHERE id_banner = " + id;

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = _query;
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        return RedirectToAction("Index");
                    }
                    catch (SqlException ex)
                    {
                        return View();
                    }
                }
            }
        }

        // GET: Banner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Banner/Delete/5
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
        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            //the "ConnStringName" is the name of your Connection String that was set up from the Web.Config


        }
    }
}
