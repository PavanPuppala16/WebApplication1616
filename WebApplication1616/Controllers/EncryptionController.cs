using Microsoft.AspNetCore.Mvc;
using WebApplication1616.Models;
using System.Data;
using WebApplication1616.encrypteddata;
using WebApplication1616.BusinessLogic_bl;
using WebApplication1616.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1616.Controllers
{
    public class EncryptionController : Controller
    {
        [HttpGet]
        public IActionResult Encryption()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Encryption(EncryptionModel obj)
        {
            if (ModelState.IsValid)
            {
                //    DataTable dt = new DataTable();
                //    dt = ENCRYPTED_bl.Insertdata(obj);
                //if(dt.Rows.Count>0)
                //{
                //    ViewData["EMAILID"] = dt.Rows[0]["EMAILID"].ToString();
                //    ViewData["PASSWORD"] = dt.Rows[0]["PASSWORD"].ToString();

                //}
                bool res = ENCRYPTED_bl.Insertdata(obj);
                if (res == true)
                {
                    return View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
    }
}
       