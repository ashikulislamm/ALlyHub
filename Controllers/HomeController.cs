﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALlyHub.Data;
using ALlyHub.Models;


namespace ALlyHub.Controllers
{
    public class HomeController : Controller
    {
        DatabaseHelper databaseHelper=new DatabaseHelper();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FindTalent()
        {             
            ViewBag.Message = "Find Talent";
        
            return View();
        }
        public ActionResult FindJobs()
        {
            ViewBag.Message = "Find Jobs";
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                int userId;
                bool isLoggedIn = DatabaseHelper.AuthenticateUser(model.Email,model.Password,out userId);
                if(isLoggedIn)
                {
                    Session["userID"]=userId.ToString();

                    return RedirectToAction("Profile", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
                
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                int userId = DatabaseHelper.RegisterUser(model.FirstName, model.LastName, model.Email, model.Password, model.Address, model.Phone);
                if(model.UserType== "Client")
                {
                    databaseHelper.RegisterClient(userId);
                }
                else if(model.UserType== "Developer")
                {
                    databaseHelper.RegisterDeveloper(userId);
                }
                return RedirectToAction("Login", "Home");
            }
            return View(model);
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Task()
        {
            return View();
        }
        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Edit_Profile()
        {
            return View();
        }
        public ActionResult Logout()
        {
            // Clear session on logout
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}