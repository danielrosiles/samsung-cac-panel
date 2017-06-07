using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SamsungTest1.Models;
using System.Data.SqlClient;
using System.Data;

namespace SamsungTest1.Controllers
{
    public class MainPanelController : Controller
    {
        hyperiondg_samsung_sales_forceEntities entidad = new hyperiondg_samsung_sales_forceEntities();
        // GET: MainPanel
        public ActionResult Index()
        {
            var listadoClientes = entidad.usuario;
            return View(listadoClientes.ToList());
            
        }

        // GET: MainPanel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MainPanel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainPanel/Create
        [HttpPost]
        public ActionResult Create(string usuario, string nombre,string apellidos,string email, string contrasenia)
        {
            if (usuario == "" | nombre == "" | apellidos == "" | email == "" | contrasenia == "")
            {
                return View();

            }
            var Newcliente = "'" + nombre + 
                            "', '" + apellidos +
                           "', '" + email +
                           "', '" + usuario +
                           "', '" + contrasenia +
                           "', '" + DateTime.Now + "'";

            string _connStr = GetConnectionString();
            string _query = "INSERT INTO[dbo].[usuario]( [nombre],[apellido], [email], [usuario], [contrasenia], [fecha_creacion]) VALUES(" + Newcliente + ")";
            
               
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

        // GET: MainPanel/Edit/5
        public ActionResult Edit(int id)
        {
            usuario editableUser=null;
            var listadoClientes = entidad.usuario;
            List<usuario> listadoUsuario = listadoClientes.ToList();
            foreach (var item in listadoUsuario)
            {
                if (item.Id_administrador == id)
                {
                    editableUser = item;
                }
            }
            TempData["id"] = editableUser.Id_administrador;
            TempData["user"] = editableUser.usuario1;
            TempData["mail"] = editableUser.email;
            TempData["nombre"] = editableUser.nombre;
            TempData["apellidos"] = editableUser.apellido;

            return View();
        }

        // POST: MainPanel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string usuario, string nombre, string apellidos, string email, string contrasenia)
        {
            if (usuario == "" | nombre == "" | apellidos == "" | email == "" | contrasenia == "")
            {
                return RedirectToAction("Edit", new { id = id });

            }


            string _connStr = GetConnectionString();
            string _query = "UPDATE[dbo].[usuario]" +
                            "SET [nombre]='" + nombre + "',[apellido]='" + apellidos + "', [email]='" + email + "', [usuario]='" + usuario + "', [contrasenia]='" + contrasenia + "',[fecha_creacion]='" + DateTime.Now + "'"+ 
                            "WHERE Id_administrador = "+id;

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

        // GET: MainPanel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainPanel/Delete/5
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
            string _query = "DELETE FROM [dbo].[usuario] WHERE Id_administrador =" + id;


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
