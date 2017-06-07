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
    public class EquiposController : Controller
    {
        hyperiondg_samsung_sales_forceEntities entidad = new hyperiondg_samsung_sales_forceEntities();
        // GET: Equipos
        public ActionResult Index()
        {
            var listadoClientes = entidad.equipo;
            return View(listadoClientes.ToList());
        }

        // GET: Equipos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Equipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipos/Create
        [HttpPost]
        public ActionResult Create(string nombre, string sku, string camara, string procesador, string pantalla, string descripcion, int id_disponibilidad, HttpPostedFileBase imagen_1, HttpPostedFileBase imagen_2, HttpPostedFileBase imagen_3, HttpPostedFileBase video_producto, HttpPostedFileBase modelo_producto, HttpPostedFileBase brochere_producto, string id_familia)
        {
            if (nombre == "" |sku==""|camara==""|procesador==""|pantalla=="")
            {
                return View();
            }
            string img1_path = "";
            string img2_path = "";
            string img3_path = "";
            string video_path = "";
            string modelo_path = "";
            string brochure_path = "";
            string disponibilidad = "";
            if (id_disponibilidad == 0)
            {
                disponibilidad = "Disponible";
            }
            else
            {
                disponibilidad = "No Disponible";
            }
            if (imagen_1 != null && imagen_1.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(imagen_1.FileName);
                string newpath = Server.MapPath("~/Content/Resources/images/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                imagen_1.SaveAs(path);
                img1_path = imagen_1.FileName;
            }
            if (imagen_2 != null && imagen_2.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(imagen_2.FileName);
                string newpath = Server.MapPath("~/Content/Resources/images/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                imagen_2.SaveAs(path);
                img2_path = imagen_2.FileName;
            }
            if (imagen_3 != null && imagen_3.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(imagen_3.FileName);
                string newpath = Server.MapPath("~/Content/Resources/images/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                imagen_3.SaveAs(path);
                img3_path = imagen_3.FileName;
            }
            if (video_producto != null && video_producto.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(video_producto.FileName);
                string newpath = Server.MapPath("~/Content/Resources/videos/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                video_producto.SaveAs(path);
                video_path = video_producto.FileName;
            }
            if (modelo_producto != null && modelo_producto.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(modelo_producto.FileName);
                string newpath = Server.MapPath("~/Content/Resources/images/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                modelo_producto.SaveAs(path);
                modelo_path = modelo_producto.FileName;
            }
            if (brochere_producto != null && brochere_producto.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(brochere_producto.FileName);
                string newpath = Server.MapPath("~/Content/Resources/brochure/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                brochere_producto.SaveAs(path);
                brochure_path=brochere_producto.FileName;
            }
            //HttpPostedFileBase imagen_1, HttpPostedFileBase imagen_2, HttpPostedFileBase imagen_3, HttpPostedFileBase video_producto, HttpPostedFileBase modelo_producto, HttpPostedFileBase brochere_producto


            var Newcliente = "'" + nombre +
                            "', '" + sku +
                           "', '" + camara +
                           "', '" + procesador +
                           "', '" + pantalla +
                           "', '" + descripcion +
                           "', '" + disponibilidad +
                           "', '" + img1_path +
                           "', '" + img2_path +
                           "', '" + img3_path +
                           "', '" + video_path +
                           "', '" + modelo_path +
                           "', '" + brochure_path +
                            "', '" + DateTime.Now +
                           "', '" + id_familia + "'";

            string _connStr = GetConnectionString();
            string _query = "INSERT INTO[hyper_hyperiondg].[equipo]( [nombre], [sku], [camara], [procesador],[pantalla], [descripcion],[disponibilidad],[imagen_1],[imagen_2],[imagen_3],[video_producto],[3D_producto],[brochure],[fecha_creacion],[familia]) VALUES(" + Newcliente + ")";


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
            return View();
        }

            // GET: Equipos/Edit/5
            public ActionResult Edit(int id)
        {
            equipo editableItem = null;
            var listadoEquipo = entidad.equipo;
            List<equipo> Equipos = listadoEquipo.ToList();
            foreach (var item in Equipos)
            {
                if (item.id_equipo== id)
                {
                    editableItem = item;
                }
            }
            TempData["id"] = editableItem.id_equipo;
            TempData["nombre"] = editableItem.nombre;
            TempData["descripcion"] = editableItem.descripcion;
            TempData["sku"] = editableItem.sku;
            TempData["id_familia"] = editableItem.familia;
            if (editableItem.disponibilidad == "Disponible")
            {
                TempData["disponibilidad"] = 0;
            }
            else
            {
                TempData["disponibilidad"] = 1;
            }
            if (editableItem.imagen_1!=null) {
                TempData["imagen_1"] = editableItem.sku + "/" + editableItem.imagen_1;
            }
            else
            {
                TempData["imagen_1"] = "";
            }
            if (editableItem.imagen_2 != null)
            {
                TempData["imagen_2"] = editableItem.sku + "/" + editableItem.imagen_2;
            }
            else
            {
                TempData["imagen_2"] = "";
            }
            if (editableItem.imagen_3 != null)
            {
                TempData["imagen_3"] = editableItem.sku + "/" + editableItem.imagen_3;
            }
            else
            {
                TempData["imagen_3"] = "";
            }
            if (editableItem.video_producto != null)
            {
                TempData["video_producto"] = editableItem.sku + "/" + editableItem.video_producto;
            }
            else
            {
                TempData["video_producto"] = "";
            }
            if (editableItem.C3D_producto != null)
            {
                TempData["C3D_producto"] =  editableItem.sku + "/" + editableItem.C3D_producto;
            }
            else
            {
                TempData["C3D_producto"] = "";
            }
            if (editableItem.brochure != null)
            {
                TempData["brochure"] =  editableItem.sku + "/" + editableItem.brochure;
            }
            else
            {
                TempData["brochure"] = "";
            }
            return View();
        }

        // POST: Equipos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,  string descripcion,  int id_disponibilidad, HttpPostedFileBase imagen_1, HttpPostedFileBase imagen_2, HttpPostedFileBase imagen_3, HttpPostedFileBase video_producto, HttpPostedFileBase modelo_producto, HttpPostedFileBase brochere_producto, string id_familia)
        {

            equipo editableItem = null;
            var listadoEquipo = entidad.equipo;
            List<equipo> Equipos = listadoEquipo.ToList();
            foreach (var item in Equipos)
            {
                if (item.id_equipo == id)
                {
                    editableItem = item;
                }
            }
            string sku = editableItem.sku;
            string img1_path = "";
            string img2_path = "";
            string img3_path = "";
            string video_path = "";
            string modelo_path = "";
            string brochure_path = "";
            string disponibilidad = "";
            if (id_disponibilidad == 0)
            {
                disponibilidad = "Disponible";
            }
            else
            {
                disponibilidad = "No Disponible";
            }
            if (imagen_1 != null && imagen_1.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(imagen_1.FileName);
                string newpath = Server.MapPath("~/Content/Resources/images/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                imagen_1.SaveAs(path);
                img1_path = imagen_1.FileName;
            }
            else
            {
                img1_path = editableItem.imagen_1;
            }
            if (imagen_2 != null && imagen_2.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(imagen_2.FileName);
                string newpath = Server.MapPath("~/Content/Resources/images/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                imagen_2.SaveAs(path);
                img2_path = imagen_2.FileName;
            }
            else
            {
                img2_path = editableItem.imagen_2;
            }
            if (imagen_3 != null && imagen_3.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(imagen_3.FileName);
                string newpath = Server.MapPath("~/Content/Resources/images/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                imagen_3.SaveAs(path);
                img3_path = imagen_3.FileName;
            }
            else
            {
                img3_path = editableItem.imagen_3;
            }
            if (video_producto != null && video_producto.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(video_producto.FileName);
                string newpath = Server.MapPath("~/Content/Resources/videos/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                video_producto.SaveAs(path);
                video_path = video_producto.FileName;
            }
            else
            {
                video_path = editableItem.video_producto;
            }
            if (modelo_producto != null && modelo_producto.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(modelo_producto.FileName);
                string newpath = Server.MapPath("~/Content/Resources/images/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                modelo_producto.SaveAs(path);
                modelo_path = modelo_producto.FileName;
            }
            else
            {
                modelo_path = editableItem.C3D_producto;
            }
            if (brochere_producto != null && brochere_producto.ContentLength > 0)
            {
                string picname = System.IO.Path.GetFileName(brochere_producto.FileName);
                string newpath = Server.MapPath("~/Content/Resources/brochure/" + sku);
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                string path = System.IO.Path.Combine(newpath, picname);
                brochere_producto.SaveAs(path);
                brochure_path = brochere_producto.FileName;
            }
            
            else
            {
                brochure_path = editableItem.brochure;
            }
            
            string _connStr = GetConnectionString();
            //string _query = "INSERT INTO[hyper_hyperiondg].[equipo]( [nombre], [sku], [camara], [procesador],[pantalla], [descripcion],[disponibilidad],[imagen_1],[imagen_2],[imagen_3],[video_producto],[3D_producto],[brochure],[fecha_creacion]) VALUES(" + Newcliente + ")";

            string _query = "UPDATE[hyper_hyperiondg].[equipo]" +
                            "SET [descripcion]='" + descripcion + "', [disponibilidad]='" + disponibilidad + "', [imagen_1]='" + img1_path + "',[imagen_2]='" + img2_path + "',[imagen_3]='" + img3_path + "',[video_producto]='" + video_path + "',[3D_producto]='" + modelo_path + "',[brochure]='" + brochure_path + "',[familia]='" + id_familia + "'" +
                            "WHERE id_equipo = " + id;

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

        // GET: Equipos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Equipos/Delete/5
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
