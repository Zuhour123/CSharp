using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Initialize base quote amount
                decimal baseQuote = 50.00m;

                // Calculate the insuree's age
                DateTime currentDate = DateTime.Today;
                int calculatedAge = currentDate.Year - insuree.DateOfBirth.Year;
                if (insuree.DateOfBirth > currentDate.AddYears(-calculatedAge))
                {
                    calculatedAge--;
                }

                // Adjust quote based on age brackets
                if (calculatedAge <= 18)
                {
                    baseQuote += 100m;
                }
                else if (calculatedAge >= 19 && calculatedAge <= 25)
                {
                    baseQuote += 50m;
                }
                else // 26 and older
                {
                    baseQuote += 25m;
                }

                // Adjust quote based on car year
                bool isOldOrNewCar = insuree.CarYear < 2000 || insuree.CarYear > 2015;
                if (isOldOrNewCar)
                {
                    baseQuote += 25m;
                }

                // Adjust quote based on car make and model
                string carMakeLower = insuree.CarMake.ToLower();
                string carModelLower = insuree.CarModel.ToLower();

                if (carMakeLower == "porsche")
                {
                    baseQuote += 25m;
                    if (carModelLower == "911 carrera")
                    {
                        baseQuote += 25m;
                    }
                }

                // Add additional charges for speeding tickets
                int ticketCount = insuree.SpeedingTickets;
                baseQuote += ticketCount * 10m;

                // Add surcharge for DUI
                if (insuree.DUI)
                {
                    baseQuote *= 1.25m;
                }

                // Add surcharge for full coverage
                if (insuree.CoverageType)
                {
                    baseQuote *= 1.50m;
                }

                // Save final quote to the object
                insuree.Quote = baseQuote;
                db.Insurees.Add(insuree);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();
            return View(insurees);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
