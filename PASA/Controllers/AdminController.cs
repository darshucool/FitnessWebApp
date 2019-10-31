using NETAUCTION;
using PASA.DataAccess;
using PASA.Domain;
using PASA.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PASA.Controllers
{
    public class AdminController : Controller
    {
        RegistrationService _registrationService = new RegistrationService();
        sliderService _sliderService = new sliderService();


        public ActionResult Logout()
        {
            return RedirectToAction("Index","Home");
        }

        public ActionResult Home()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login","Home");
            }
            //List<Registration> reg = new List<Registration>();
            List<Student> studentList = new List<Student>();

            try
            {
                //reg = _registrationService.SelectRegistrationList();
                studentList = _registrationService.SelectStudentList();
            }
            catch (Exception)
            {
                throw;
            }
            return View(studentList);
        }
        public ActionResult SliderList()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login","Home");
            }
            //List<Registration> reg = new List<Registration>();
            List<Slider> sliderList = new List<Slider>();

            try
            {
                //reg = _registrationService.SelectRegistrationList();
                sliderList = _sliderService.SelectSliderList();
            }
            catch (Exception)
            {
                throw;
            }
            return View(sliderList);
        }
        public ActionResult EditSlider(int id)
        {
            Slider oSlider = new Slider();
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            //List<Registration> reg = new List<Registration>();
            List<Slider> sliderList = new List<Slider>();

            try
            {
                
                oSlider.UId = id;
                //reg = _registrationService.SelectRegistrationList();
                oSlider = _sliderService.SelectSlider(oSlider);
            }
            catch (Exception)
            {
                throw;
            }
            return View(oSlider);
        }
        public bool IsFileSupported(HttpPostedFileBase file)
        {
            var isSupported = false;

            switch (file.ContentType)
            {

                case ("image/gif"):
                    isSupported = false;
                    break;

                case ("image/jpeg"):
                    isSupported = true;
                    break;

                case ("image/png"):
                    isSupported = true;
                    break;


                case ("audio/mp3"):
                    isSupported = false;
                    break;

                case ("audio/wav"):
                    isSupported = false;
                    break;

                default:
                    isSupported = false;
                    break;
            }

            return isSupported;
        }
        [HttpPost]
        public ActionResult EditSlider(int id, FormCollection Form, HttpPostedFileBase file)
        {
            Slider oSlider = new Slider();
            try
            {

                oSlider.UId = id;
                oSlider = _sliderService.SelectSlider(oSlider);
                TryUpdateModel(oSlider);
                if (file != null)
                {
                    bool isFileSupported = IsFileSupported(file);

                    if (!isFileSupported)
                    {
                        TempData[ViewDataKeys.Message] = new FailMessage("Upload a valid Main image format");
                        return View(oSlider);
                    }
                    if (file != null)
                    {
                        string ImagePath = "~/Asset/img/slides/" + oSlider.ImgPath;
                        WebImage img = new WebImage(file.InputStream);
                        if (img.Width > 1600)
                        {
                            int width = 1600;
                            int height = (int)Math.Round(((width * 1.0) / img.Width) * img.Height);
                            img.Resize(width, height, false, true).Crop(1, 1);
                        }
                        if (System.IO.File.Exists(Server.MapPath(ImagePath)))
                        {
                         System.IO.File.Delete(Server.MapPath(ImagePath));
                        }
                        string NewPath = "~/Asset/img/slides/";
                        var fileNameNew = Path.GetFileName(file.FileName);
                        var fileExtnNew = Path.GetExtension(file.FileName);
                        NewPath += fileNameNew;
                        img.Save(NewPath);
                        oSlider.ImgPath = fileNameNew;
                        bool status=_sliderService.UpdateSlider(oSlider);
                        if(status)
                        TempData[ViewDataKeys.Message] = new SuccessMessage("Successfully Updated");
                        else
                         TempData[ViewDataKeys.Message] = new FailMessage("Error Occured");
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return View(oSlider);
        }
        public ActionResult ViewMore(int id)
        {
            //Registration reg = new Registration();
            Student oStudent = new Student();
            try
            {
                oStudent.Id = id;
                oStudent = _registrationService.SelectStudent(oStudent);
            }
            catch (Exception)
            {
                throw;
            }
            return View(oStudent);
        }
    }
}
