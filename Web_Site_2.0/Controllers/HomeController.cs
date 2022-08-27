using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Site_2._0.Models;


namespace Web_Site_2._0.Controllers
{
    
    public class HomeController : Controller
    {
        public TransportEntities db = new TransportEntities();
        public ActionResult Index()
        {            
            return View();
        }

        
        public ActionResult Login()
        {
            if ((string)Session["IsUserLoggedIn"] == "Student")
            {
                return RedirectToAction("Student");
            }
            else
            {

                return View();
            }

        }
        public ActionResult Logout()
        {
            Session["IsUserLoggedIn"] = null;
            
                return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Signup()
        {
            return View("~/Views/Student/Create.cshtml");
        }


        [HttpPost]
        public ActionResult AuthenticateUser(FormCollection form)
        {

            string Username = form.Get("username");
            string Password = form.Get("password");

            //Username = "admin";
            // Password = "1234";

            //var std = db.Student_Info.Where(a => a.Std_Password.Equals(Password) && a.Std_Id.Equals(Username)).FirstOrDefault();
            //var admin = db.Admin_Password.Where(a => a.Admin_Password1.Equals(Password) && a.Admin_Id.Equals(Username)).FirstOrDefault();

            if (Username != null && Password != null)
            {
                if (Username == "student" )
                {
                    Session["IsUserLoggedIn"] = "Student";
                    Session["Username"] = Username;
                    //return RedirectToAction("Student","Student", new { id = Username });
                    return View("Student");
                }
                if (Username ==  "admin")
                {
                    Session["IsUserLoggedIn"] = "Admin";
                    Session["Username"] = Username;
                    return View("Admin");
                }
                else
                {
                    TempData["Error"] = "Username or password incorrect,please try again ";

                    return RedirectToAction("Login");
                }

               

            }
            else
            {
                TempData["Error"] = "User name and password must not be empty";

                return RedirectToAction("Login");
            }
         
         
        }


       
        public ActionResult Student()
        {
            if ((string)Session["IsUserLoggedIn"] == "Student")
            {
                var stdid = 100004;

                Student_Info Student = db.Student_Info.Find(stdid);
                //Van_Students van_Students = db.Van_Students.Find(student_Info.Std_Id);
                //VanDriver_Info vanDriver_Info = db.VanDriver_Info.Find(van_Students.P_ID);

                return View(Student);
            }
            else
            {

                return View("Login");
            }
  

        }
        public ActionResult Driver(Driver_Info driver_Info)
        {
            var dri = 12;
            Driver_Info driver = db.Driver_Info.Find(dri);

            return View(driver);

        }
        public ActionResult Routes()
        {
            var id = 12;
            return View(db.Routes_Info.Where(x => x.RouteID == id).FirstOrDefault());

        }
        public ActionResult Vehicle_Info()
        {
            var id = 5;
            return View(db.Vehicle_Info.Where(x => x.Van_Id == id).FirstOrDefault());

        }

        public ActionResult Admin()
        {
            if ((string)Session["IsUserLoggedIn"] != "Admin")
            {
                return RedirectToAction("Login");
            }
            else
            {

                return View();
            }
           
        }

        public ActionResult Student_Edit()
        {
            if ((string)Session["IsUserLoggedIn"] != "Admin")
            {
                return RedirectToAction("Login");
            }
            else
            {

                return View("~/Views/Student/Edit");
            }

        }


       


    }
}

