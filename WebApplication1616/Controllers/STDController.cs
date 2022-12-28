﻿using Microsoft.AspNetCore.Mvc;

using WebApplication1616;
using System.Data;
using WebApplication1616.BusinessLogic_bl;
using WebApplication1616.Models;
using System.Net;
using System.Net.Mail;
using System.Configuration;



namespace WebApplication1616.Controllers
{

    public class STDController : Controller
    {

        [HttpGet]
        public IActionResult LOGIN()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LOGIN(STDMODELlogin OBJ)
        {
            if (ModelState.IsValid)
            {
                DataTable dt = new DataTable();
                dt = STDLogics.login(OBJ);

                if (dt.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("UserName", dt.Rows[0]["Name"].ToString());
                    HttpContext.Session.SetString("Time", System.DateTime.Now.ToShortTimeString());
                    if (dt.Rows[0]["Status"].ToString().ToLower() == "true")  // active
                    {
                        if (dt.Rows[0]["ROLE"].ToString() == "STUDENT")  // std
                        {
                            Random rand = new Random();
                            HttpContext.Session.SetString("OTP", rand.Next(1111, 9999).ToString());
                            bool result = SendEmail(OBJ.emailid);
                            if (result == true)
                            {
                                return RedirectToAction("VerifyOtp", "STD");
                            }
                            
                        }
                        else if (dt.Rows[0]["ROLE"].ToString() == "PRINCIPLE")  // staff 
                        {
                            return RedirectToAction("ADMIN", "STD");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "USer Is InActive");
                    }
                    return RedirectToAction("Home", "STD");
                }

                else
                {
                    return View(OBJ);
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        [SetSessionGlobally]
        public IActionResult REGISTER()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult REGISTER(STDMODEL OBJ)
        {
            ViewBag.Message = "formsubmitted";
            if (ModelState.IsValid)
            {
                bool res = STDLogics.Insertdata(OBJ);

                if (res == true)
                {

                    return View("LOGIN");
                }
                else
                {
                    return View(OBJ);
                }
            }
            else
            {
                return View(OBJ);
            }
        }
       
        [HttpGet]
        public IActionResult Forgetpassword()
        {
            return View();
        }
        public IActionResult Forgetpassword(STDMODEL OBJ)
        {
            Random rand = new Random();
            HttpContext.Session.SetString("OTP", rand.Next(1111, 9999).ToString());
            bool result = SendEmail(OBJ.Emailid);
            if (result == true)
            {
               
                return RedirectToAction("FORGOTPASSWORDOtp", "STD");
            }
            return View();
        }
        [HttpGet]
        public IActionResult FORGOTPASSWORDOtp()
        {    
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FORGOTPASSWORDOtp(OtpModel obj)
        {
            
                if (obj.Otp.Equals(HttpContext.Session.GetString("OTP")))
                {
                    return RedirectToAction("SETTINGNEWPASSWORD", "STD");
                }
                else
                {
                    return View();
                }
                return View();
        }

        [HttpGet]
        public IActionResult SETTINGNEWPASSWORD()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SETTINGNEWPASSWORD(ForgetPasswordModel OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = STDLogics.UPDATEDATABYEMAILID(OBJ);
                if (res == true)
                {
                    return RedirectToAction("LOGIN","STD");
                }
                else
                {
                    return View(OBJ);
                }
            }
            else
            {
                return View(OBJ);
            }
        }



        public IActionResult Homepage()
        {
            return View();
        }
        public IActionResult ADMIN()
        {
            return View();
        }

        [SetSessionGlobally]
        public IActionResult Home()
        {
            ViewBag.Message = "Login Successful";

            return View();
        }
        public IActionResult LIBRARY()
        {
            return View();
        }
        public IActionResult CONTACT()
        {
            return View();
        }
        public IActionResult CheckBox()
        {
            return View();
        }

        [HttpGet]
        [OutputCache(Duration = 10)]
        public IActionResult DisplayData()
        {
            return View(DISPLAYDATA.GetALLData());
        }


        public IActionResult EDITBYMAIL()
        {
            return View();
        }

       
        public IActionResult EDIT(String? ROLLNO)
        {
            return View(STDLogics.GetDataByROLLNO((String)ROLLNO));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EDIT(STDMODEL OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = STDLogics.UPDATEDATABYROLLNO(OBJ);
                if (res == true)
                {
                    return RedirectToAction("DispalyData", "STD");
                }
                else
                {
                    return View(STDLogics.UPDATEDATABYROLLNO(OBJ));
                }
            }
            else
            {
                return View();
            }
            }

            public IActionResult DELETEDATA(String? ROLLNO)
        {
            if (ModelState.IsValid)
            {
                bool res = STDLogics.DELETEDataByROLLNO((String)ROLLNO);
                if (res == true)
                {
                    return RedirectToAction("DispalyData", "STD");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View((String)ROLLNO);
            }
        }
        public IActionResult POPUPMSG()
        {
            return View();
        }
        [SetSessionGlobally]
        public IActionResult LOGOUT()
        {
            HttpContext.Session.Clear();
            return View();
        }

        public bool SendEmail(string receiver)
        {
            bool chk = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("pavanpuppala1616@gmail.com");
                mail.To.Add(receiver);
                mail.IsBodyHtml = true;
                mail.Subject = "OTP";
                mail.Body = "Your OTP is :" + HttpContext.Session.GetString("OTP");
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("pavanpuppala1616@gmail.com", "yvddbdfpddgilocn");
                client.EnableSsl = true;
                client.Send(mail);
                chk = true;
            }
            catch (Exception)
            {
                throw;
            }
            return chk;
        }

    


        [HttpGet]
        public IActionResult VerifyOtp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyOtp(OtpModel obj)
        {
            if (obj.Otp.Equals(HttpContext.Session.GetString("OTP")))
            {
                return RedirectToAction("Home", "STD");
            }
            else
            {
                return View();
            }
        }
       
    }
}