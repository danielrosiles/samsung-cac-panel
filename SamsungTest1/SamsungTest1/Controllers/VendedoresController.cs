using LumenWorks.Framework.IO.Csv;
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
    public class VendedoresController : Controller
    {
        hyperiondg_samsung_sales_forceEntities entidad = new hyperiondg_samsung_sales_forceEntities();
        // GET: Vendedores
        public ActionResult Index()
        {
            var listadoClientes = entidad.samsung_vendedores;
            return View(listadoClientes.ToList());
        }

        // GET: Vendedores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vendedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendedores/Create
        [HttpPost]
        public ActionResult Create(string nombre, string email, string no_vendedor, string operador, string region)
        {
            if (nombre == "" | email == "" | no_vendedor == "" | operador == "" | region == "")
            {
                return View();

            }

            var Newcliente = "'" + nombre +
                            "', '" + email +
                           "', '" + no_vendedor +
                           "', '" + operador +
                           "', '" + region +
                           "', '" + DateTime.Now + "'";

            string _connStr = GetConnectionString();
            string _query = "INSERT INTO[dbo].[samsung_vendedores]( [nombre], [email], [numero], [operador],[region], [fecha_creacion]) VALUES(" + Newcliente + ")";


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

        // GET: Vendedores/Edit/5
        public ActionResult Edit(int id)
        {
            samsung_vendedores editableUser = null;
            var listadoClientes = entidad.samsung_vendedores;
            List<samsung_vendedores> listadoUsuario = listadoClientes.ToList();
            foreach (var item in listadoUsuario)
            {
                if (item.Id_vendedores == id)
                {
                    editableUser = item;
                }
            }
            TempData["id"] = editableUser.Id_vendedores;
            TempData["nombre"] = editableUser.nombre;
            TempData["email"] = editableUser.email;
            TempData["numero"] = editableUser.numero;
            TempData["operador"] = editableUser.operador;
            TempData["region"] = editableUser.region;
            return View();
        }

        // POST: Vendedores/Edit/5
        [HttpPost]
        public ActionResult Edit( int id,string nombre, string email, string no_vendedor, string operador, string region)
        {
            if (nombre == "" | email == "" | no_vendedor == "" | operador == "" | region == "")
            {
                return RedirectToAction("Edit", new { id = id });

            }
            string _connStr = GetConnectionString();
            string _query = "UPDATE[dbo].[samsung_vendedores]" +
                            "SET [nombre]='" + nombre + "',[email]='" + email + "', [numero]='" + no_vendedor + "', [operador]='" + operador + "', [region]='" + region + "',[fecha_creacion]='" + DateTime.Now + "'" +
                            "WHERE Id_vendedores = " + id;

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

        // GET: Vendedores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vendedores/Delete/5
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
        [HttpPost]
        public ActionResult DeleteData(int id)
        {

            string _connStr = GetConnectionString();
            string _query = "DELETE FROM [dbo].[samsung_vendedores] WHERE Id_vendedores =" + id;


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
                        return View("Index");
                    }
                }
            }
        }


        
        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            //the "ConnStringName" is the name of your Connection String that was set up from the Web.Config


        }
    }
}
