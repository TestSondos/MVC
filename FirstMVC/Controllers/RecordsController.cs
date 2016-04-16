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
        // GET: Records
        public ActionResult Index()
        {
            RecordEntity recordA = new RecordEntity (Helper.Instance.UserId, DateTime.UtcNow.ToString())
            {
                title = "Blood Pressure",
                description = "Your Blood Pressure was 110/70 at 3:10 \nThe normal is 120/80"
            };
            //RecordEntity recordB = new RecordEntity(Helper.Instance.UserId, DateTime.UtcNow.ToString())
            //{
            //    title = "Weight",
            //    description = "Your weight is 65KG and you're great now"
            //};

            AzureStore A = new AzureStore();
            A.AddRecord(recordA);

            ViewData.ToString();

            //A.AddRecord(recordB);
            Console.WriteLine("Your Records are here :)");
            return View();
        }

        // GET: Records/Details/5
        public ActionResult Details(int id)
        {
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
