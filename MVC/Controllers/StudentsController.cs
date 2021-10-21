using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MVC.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index(int? page)
        {
            IEnumerable<MvcStudentsModel> studList;
            System.Net.Http.HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Students").Result;
            studList = response.Content.ReadAsAsync<IEnumerable<MvcStudentsModel>>().Result.ToPagedList(page?? 1,10);
            return View(studList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id==0)
            return View(new MvcStudentsModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Students/"+ id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcStudentsModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcStudentsModel stud)
        {
            if (stud.StudentID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Students", stud).Result;
                TempData["SuccessMessage"] = "Add New Student Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Students/"+stud.StudentID, stud).Result;
                TempData["SuccessMessage"] = "Details Updated Successfully";

            }
           
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Students/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Student Details Successfully";

            return RedirectToAction("Index");
        }
    }
}