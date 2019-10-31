using NETAUCTION;
using PASA.DataAccess;
using PASA.Domain;
using PASA.Helpers;
using PASA.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PASA.Controllers
{
    public class HomeController : Controller
    {
        RegistrationService _registrationService = new RegistrationService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }

        public ActionResult courses()
        {
            return View();
        }

        public ActionResult register()
        {
            return View();
        }

        public ActionResult Student()
        {
            return View();
        }

        public ActionResult events()
        {
            return View();
        }

        public ActionResult gallery()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        public ActionResult baby_with_parent()
        {
            return View();
        }

        public ActionResult nursery_kids()
        {
            return View();
        }

        public ActionResult primary_kids_activity()
        {
            return View();
        }
                
        public ActionResult secondary_children_activity()
        {
            return View();
        }

        public ActionResult SecondaryTeenagersActivity()
        {
            return View();
        }

        public ActionResult AdolescenceActivity()
        {
            return View();
        }

        public ActionResult AdultsGroup()
        {
            return View();
        }

        public ActionResult trainer_profile1()
        {
            return View();
        }

        public ActionResult trainer_profile2()
        {
            return View();
        }

        public ActionResult trainer_profile3()
        {
            return View();
        }

        public ActionResult trainer_profile4()
        {
            return View();
        }

        public ActionResult trainer_profile5()
        {
            return View();
        }

        public ActionResult trainer_profile6()
        {
            return View();
        }

        public ActionResult trainer_profile7()
        {
            return View();
        }

        public ActionResult trainer_profile8()
        {
            return View();
        }

        public ActionResult trainer_profile9()
        {
            return View();
        }

        public ActionResult trainer_profile10()
        {
            return View();
        }

        public ActionResult trainer_profile11()
        {
            return View();
        }

        public ActionResult trainer_profile12()
        {
            return View();
        }

        public ActionResult trainer_profile13()
        {
            return View();
        }

        public ActionResult trainer_profile14()
        {
            return View();
        }

        public ActionResult trainer_profile15()
        {
            return View();
        }

        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(FormCollection Form)
        {
            LoginModel model = new LoginModel();
            TryUpdateModel(model);
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Username == "admin" && model.Password == "password@123")
                    {
                        Session["User"] = "admin";
                        return RedirectToAction("Home","Admin");
                       
                    }
                    else
                    {
                        TempData[ViewDataKeys.Message] = new FailMessage("Invalide Login details.");
                        return RedirectToAction("Login");
                    }
                }
            }
            catch (Exception)
            {                
                throw;
            }
            return View(model);
        }
        
        public ActionResult RegisterCustomer()
        {
            Registration oRegistration = new Registration();
            oRegistration.DOB = DateTime.Now.Date;
            return View(oRegistration);
        }

        [HttpPost]
        public ActionResult RegisterCustomer(FormCollection Form)
        {
            Registration model = new Registration();
            try
            {
                TryUpdateModel(model);
                ModelState.Remove("UId");
                ModelState.Remove("ModifiedDate");
                ModelState.Remove("ModifiedBy");
                ModelState.Remove("CreatedDate");
                ModelState.Remove("CreatedBy");
                ModelState.Remove("Active");
                ModelState.Remove("IsRentBuilding");
                ModelState.Remove("IsMarried");
                ModelState.Remove("IsRentGround");
                ModelState.Remove("IsArrested");
                if (ModelState.IsValid)
                {                   
                    int MarriedID = int.Parse(Form["IsMarried"].ToString());
                    if (MarriedID == 1)
                        model.IsMarried = true;
                    else
                        model.IsMarried = false;
                    model.ProfessionalStatus = Form["ProfessionalStatus"].ToString();
                    model.OtherCatDesc = Form["OtherCatDesc"].ToString();
                    model.EduQualification = Form["EduQualification"].ToString();
                    model.Sports = Form["Sports"].ToString();
                    model.OtherCatSports = Form["OtherCatSports"].ToString();

                    int RentBuild = int.Parse(Form["IsRentBuilding"].ToString());
                    if (RentBuild == 1)
                        model.IsRentBuilding = true;
                    else
                        model.IsRentBuilding = false;

                    int IsRentGround = int.Parse(Form["IsRentGround"].ToString());
                    if (IsRentGround == 1)
                        model.IsRentGround = true;
                    else
                        model.IsRentGround = false;

                    model.MoneySpendId = int.Parse(Form["MoneySpendId"].ToString());

                    int IsArrested = int.Parse(Form["IsArrested"].ToString());
                    if (IsArrested == 1)
                        model.IsArrested = true;
                    else
                        model.IsArrested = false;
                    model.Active = true;
                    model.CreatedBy = 1;
                    model.CreatedDate = DateTime.Now;
                    int state = new RegistrationService().InsertRegistration(model);
                    if (state > 0)
                    {
                        TempData[ViewDataKeys.Message] = new SuccessMessage("You have successfuly registred with us. We will back to you as soon as possible.");
                        return RedirectToAction("register");
                    }
                    else
                    {
                        TempData[ViewDataKeys.Message] = new FailMessage("Error Occured.");
                        return RedirectToAction("register");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(model);
        }

        public ActionResult RegisterStudent()
        {
            Student oStudent = new Student();
            oStudent.DOB = DateTime.Now.Date;
            return RedirectToAction("Student", oStudent); 
        }

        [HttpPost]
        public ActionResult RegisterStudent(FormCollection Form)
        {
            Student oStudent = new Student();
            try
            {
                TryUpdateModel(oStudent);
                ModelState.Remove("Id");
                ModelState.Remove("ModifiedDate");
                ModelState.Remove("ModifiedBy");
                ModelState.Remove("CreatedDate");
                ModelState.Remove("CreatedBy");
                ModelState.Remove("Active");
                if (ModelState.IsValid)
                {
                    oStudent.ActivityGroup = Form["ActivityGroup"].ToString();
                    oStudent.FullName = Form["FullName"].ToString();
                    oStudent.DOB = DateTime.Parse(Form["DOB"].ToString());
                    oStudent.Email = Form["Email"].ToString();
                    oStudent.AddressPrivate = Form["AddressPrivate"].ToString();
                    oStudent.AddressSchool = Form["AddressSchool"].ToString();
                    oStudent.TeleRes = Form["TeleRes"].ToString();
                    oStudent.TeleMob = Form["TeleMob"].ToString();
                    oStudent.Active = true;
                    oStudent.CreatedDate = DateTime.Now;

                    int state = new RegistrationService().InsertStudent(oStudent);
                    if (state > 0)
                    {
                        TempData[ViewDataKeys.Message] = new SuccessMessage("You have successfuly registred with us. We will back to you as soon as possible.");
                        return RedirectToAction("RegisterStudent");
                    }
                    else
                    {
                        TempData[ViewDataKeys.Message] = new FailMessage("Error Occured.");
                        return RedirectToAction("RegisterStudent");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(oStudent);
        }
    }
}
