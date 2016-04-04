using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _360Courier.Extensions;
using System.Security.Claims;
using FirstMVC.Helpers;
using DataLayer;

namespace FirstMVC.Controllers
{
    public class MedRecController : Controller
    {
        // GET: MedRec
        public ActionResult Index()
        {
            var dataStore = new DataStore();
            dataStore.AddMedicalRecord(Helper.Instance.UserId, DateTime.UtcNow.ToString());
            ViewBag.UserData = dataStore.GetMedicalHistory(Helper.Instance.UserId).ToJson();
            return View();
        }

        // GET: MedRec/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedRec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedRec/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MedRec/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedRec/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MedRec/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedRec/Delete/5
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
    }
}
