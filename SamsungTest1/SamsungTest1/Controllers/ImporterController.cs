using LumenWorks.Framework.IO.Csv;
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
    public class ImporterController : Controller
    {
        // GET: Importer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Importer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Importer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Importer/Create
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

        // GET: Importer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Importer/Edit/5
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

        // GET: Importer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Importer/Delete/5
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
        //Post CVS
        [HttpPost]
        public ActionResult UploadCVS(HttpPostedFileBase logo, string id_categoria)
        {

            if (logo != null && logo.ContentLength > 0)
            {

                if (logo.FileName.EndsWith(".csv"))
                {
                    Stream stream = logo.InputStream;
                    DataTable csvTable = new DataTable();
                    using (CsvReader csvReader =
                        new CsvReader(new StreamReader(stream), true))
                    {
                        csvTable.Load(csvReader);
                    }
                    //csvTable.Rows[0]["nombre"]
                    var Newcliente = "";
                    if (id_categoria == "6")
                    {
                        for (int i = 0; i < csvTable.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                Newcliente = "('" + csvTable.Rows[0]["nombre"] +
                                        "', '" + csvTable.Rows[0]["email"] +
                                       "', '" + csvTable.Rows[0]["num_vendedor"] +
                                       "', '" + csvTable.Rows[0]["operador"] +
                                       "', '" + csvTable.Rows[0]["region"] +
                                       "', '" + DateTime.Now + "')";
                            }
                            else
                            {
                                Newcliente = Newcliente + ",('" + csvTable.Rows[i]["nombre"] +
                                        "', '" + csvTable.Rows[i]["email"] +
                                       "', '" + csvTable.Rows[i]["num_vendedor"] +
                                       "', '" + csvTable.Rows[i]["operador"] +
                                       "', '" + csvTable.Rows[i]["region"] +
                                       "', '" + DateTime.Now + "')";
                            }
                        }

                        string _connStr = GetConnectionString();
                        string _query = "INSERT INTO[dbo].[samsung_vendedores]( [nombre], [email], [numero], [operador],[region], [fecha_creacion]) VALUES " + Newcliente;
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
                                    return RedirectToAction("Index", "Vendedores");
                                }
                                catch (SqlException ex)
                                {
                                    return View();
                                }
                            }
                        }
                    }
                    if (id_categoria == "5")
                    {
                        for (int i = 0; i < csvTable.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                Newcliente = "('" + csvTable.Rows[0]["nombre"] +
                                        "', '" + csvTable.Rows[0]["perfil"] +
                                       "', '" + csvTable.Rows[0]["usuario"] +
                                       "', '" + csvTable.Rows[0]["email"] +
                                       "', '" + DateTime.Now + "')";
                            }
                            else
                            {
                                Newcliente = Newcliente + ",('" + csvTable.Rows[i]["nombre"] +
                                        "', '" + csvTable.Rows[i]["perfil"] +
                                       "', '" + csvTable.Rows[i]["usuario"] +
                                       "', '" + csvTable.Rows[i]["email"] +
                                       "', '" + DateTime.Now + "')";
                            }
                        }

                        string _connStr = GetConnectionString();
                        string _query = "INSERT INTO[dbo].[samsung_cliente]( [nombre], [perfil], [usuario], [email], [fecha_creacion]) VALUES " + Newcliente;
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
                                    return RedirectToAction("Index", "Clientes");
                                }
                                catch (SqlException ex)
                                {
                                    return View();
                                }
                            }
                        }
                    }
                    else
                    {
                        return View();
                    }            
                    
                    //return View(csvTable);
                }
                else
                {
                    ModelState.AddModelError("File", "This file format is not supported");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("File", "Please Upload Your file");
            }
            return View();
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            //the "ConnStringName" is the name of your Connection String that was set up from the Web.Config


        }
    }
}
