
using MVC_JSTC_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_JSTC.Models;
using MVC_JSTC_Repository.Repositories;
using MVC_JSTC_Service;

namespace MVC_JSTC.Controllers
{
    public class HomeController : Controller
    {
        Service service = new Service();

        /****************** Default Action ************************/
        public ActionResult Index()
        {
            if (Session["User"] != null){
                return JavaScript("window.location.href = '/Products/ProductsIndex'");
            }

            else{
                return View();
            }
        }

        /****************** HTTPPOST LOGIN ACTION ************************/
        //Success --> ProductsIndex
        //Else --> ajax insert partialview of errors into index
        [HttpPost]
        public ActionResult Login(AuthenticationModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_LoginError", model);
            }

            //service function - try to login
            var result = service.TryLogin(
                model.Login.UserName.ToString(),
                model.Login.Password.ToString());

            //if login was successful
            if (result == "success")
            {
                Session["User"] = model.Login.UserName.ToString();

                return JavaScript("window.location.href = '/Products/ProductsIndex'");
            }

            if (result.Contains("name"))

            {
                ModelState.AddModelError("LoginUserError", "Username or Email Address does not exist");

            }
            if (result.Contains("password"))
            {
                ModelState.AddModelError("LoginPasswordError", "Password is incorrect");
            }

            //else return errors
            return PartialView("_LoginError", model);
        }

        /****************** HTTPPOST REGISTER ACTION ************************/
        //Success --> ProductsIndex
        //Else --> ajax insert partialview of errors into index
        [HttpPost]
        public ActionResult Register(AuthenticationModel r_model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_RegError", r_model);
            }

            //service function
            var result = service.TryCreateNewUser(
                r_model.Register.UserName.ToString(),
                r_model.Register.Email.ToString(),
                r_model.Register.Password.ToString());

            //Account creation is successful -> redirect to products page
            if (result == "success"){
                Session["User"] = r_model.Register.UserName.ToString();
                return JavaScript("window.location.href = '/Products/ProductsIndex'");
            }

            //username has been taken
            if (result.Contains("name")){
                ModelState.AddModelError("RegUserError", "This username has already been taken");
            }

            //email has been taken
            if (result.Contains("email")){
                ModelState.AddModelError("RegEmailError", "This email has already been taken");
            }

            return PartialView("_RegError", r_model);
        }


        /******************  LOGOUT ACTION ************************/
        //Ends the users session
        public ActionResult Logout()
        {
            Session.Clear();
            return JavaScript("window.location.href = '/Home/Index'");
        }
    }
}