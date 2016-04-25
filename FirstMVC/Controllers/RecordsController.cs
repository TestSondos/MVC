using AzureStorage;
using Contracts;
using FirstMVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _360Courier;
using _360Courier.Extensions;
using FirstMVC.Models;
using AzureStorage;

namespace FirstMVC.Controllers
{
    public class RecordsController : Controller
    {
        public IRecordsManager recordsManager = new AzureStore();
        public IMedicalRecord record = new RecordEntity(Helper.Instance.UserId);

        // GET: Records
        public ActionResult Index()
        {
            //var records = recordsManager.ReadAll(Helper.Instance.UserId);
            //return View(records ?? Enumerable.Empty<IMedicalRecord>());

            var records = recordsManager.ReadBP(Helper.Instance.UserId);
            return View(records ?? Enumerable.Empty<IMedicalRecord>());

            //Can't make this :(
            //var records = recordsManager.Read(Helper.Instance.UserId);
            //return View(records);
        }

        // GET: Records/Details/5
        public ActionResult Details(string id)
        {
            //return Content(record.Title, record.Description);
            
            //var rec = recordsManager.ReadBP(Helper.Instance.UserId);
            //return View(rec);
            return View();
            //return Json(new { Record = rec, Name = "Bla Bla" }, JsonRequestBehavior.AllowGet);

            //return View(rec ?? Enumerable.Empty<IMedicalRecord>());
        }

        public ActionResult AddBP()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBP(NewBPModel model)
        {
            record.Title = "Blood Pressure";
            record.Description = string.Format("Your Blood Pressure in {0} is {1}/{2}", DateTime.UtcNow.ToString(), model.S, model.D);

            recordsManager.Add(record);
            return RedirectToAction("Index");
        }

        public ActionResult AddSL()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSL (NewSLModel model)
        {
            record.Title = "Sugar Level";
            record.Description = string.Format("Your Sugar Level in {0} is {1} mg/dl", DateTime.UtcNow, model.mg);
            recordsManager.Add(record);
            return RedirectToAction("Index");
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
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

        // GET: Records/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Records/Edit/5
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

        // GET: Records/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Records/Delete/5
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

        public string recordId { get; set; }
    }
}
