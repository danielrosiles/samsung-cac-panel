using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SamsungTest1.Models;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace SamsungTest1.Controllers
{
    public class MainPanelController : Controller
    {
        hyperiondg_samsung_sales_forceEntities entidad = new hyperiondg_samsung_sales_forceEntities();
        // GET: MainPanel
        public ActionResult Index()
        {
            var listadoClientes = entidad.usuario;
            List<usuario> listadoUsuario = listadoClientes.ToList();
            foreach (var item in listadoUsuario)
            {
                item.contrasenia = Decrypt(item.contrasenia);
            }
            
            return View(listadoUsuario);
            
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
            string passwordEncode = Encrypt(contrasenia);
            var Newcliente = "'" + nombre + 
                            "', '" + apellidos +
                           "', '" + email +
                           "', '" + usuario +
                           "', '" + passwordEncode +
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
            string password = Encrypt(contrasenia);

            string _connStr = GetConnectionString();
            string _query = "UPDATE[dbo].[usuario]" +
                            "SET [nombre]='" + nombre + "',[apellido]='" + apellidos + "', [email]='" + email + "', [usuario]='" + usuario + "', [contrasenia]='" + password + "',[fecha_creacion]='" + DateTime.Now + "'"+ 
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
        public string Encrypt(string str)
        {
            string EncrptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string str)
        {
            str = str.Replace(" ", "+");
            string DecryptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[str.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
    }
}
