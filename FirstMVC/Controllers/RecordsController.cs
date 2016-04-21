using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Helpers;
using AzureStorage;

namespace FirstMVC.Controllers
{
    public class RecordsController : Controller
    {
        public RecordsController ()
        {
            RecordEntity recordA = new RecordEntity(Helper.Instance.UserId, DateTime.UtcNow.ToString())
            {
                Title = "Blood Pressure",
                Description = "Your Blood Pressure was 110/70 at 3:10 The normal is 120/80"
            };
            RecordEntity recordB = new RecordEntity(Helper.Instance.UserId, DateTime.UtcNow.ToString())
            {
                Title = "Weight",
                Description = "Your weight is 65KG and you're great now"
            };
            RecordEntity recordC = new RecordEntity(Helper.Instance.UserId, DateTime.UtcNow.ToString())
            {
                Title = "XRays",
                Description = "Your XRays are here wherever you are :)"
            };

            AzureStore A = new AzureStore();
            A.AddRecord(recordA);
            A.AddRecord(recordB);
            A.AddRecord(recordC);

            ViewBag.T1 = recordA.Title;
            ViewBag.T2 = recordB.Title;
            ViewBag.T3 = recordC.Title;

            ViewBag.D1 = recordA.Description;
            ViewBag.D2 = recordB.Description;
            ViewBag.D3 = recordC.Description;


        }
        // GET: Records
        public ActionResult Index()
        {
            return View();
        }

        // GET: Records/Details/5
        public ActionResult Details(string id)
        {
            id = Helper.Instance.UserId;
            return View();
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
    }
}
