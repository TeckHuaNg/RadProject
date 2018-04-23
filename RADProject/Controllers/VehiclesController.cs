using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RADProject.Models;

namespace RADProject.Controllers
{
    public class VehiclesController : Controller
    {
        private VehicleModel db = new VehicleModel();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.MakeId = new SelectList(db.Makes.OrderBy(m => m.Name), "MakeId", "Name");
            ViewBag.ModelId = new SelectList(db.Models.OrderBy(m => m.Name), "ModelId", "Name");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleId,MakeId,ModelId,Year,Price,SoldDate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if(Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if(file.FileName != null && file.ContentLength > 0)
                    {
                        string path = Server.MapPath("~/Content/Images/") + file.FileName;
                        file.SaveAs(path);

                        vehicle.ImageUrl = "/Content/Images/" + file.FileName;
                    }
                }

                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MakeId = new SelectList(db.Makes.OrderBy(m => m.Name), "MakeId", "Name");
            ViewBag.ModelId = new SelectList(db.Models.OrderBy(m => m.Name), "ModelId", "Name");
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MakeId = new SelectList(db.Makes.OrderBy(m => m.Name), "MakeId", "Name", vehicle.MakeId);
            ViewBag.ModelId = new SelectList(db.Models.OrderBy(m => m.Name), "ModelId", "Name", vehicle.ModelId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId,MakeId,ModelId,Year,Price,SoldDate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file.FileName != null && file.ContentLength > 0)
                    {
                        string path = Server.MapPath("~/Content/Images/") + file.FileName;
                        file.SaveAs(path);

                        vehicle.ImageUrl = "/Content/Images/" + file.FileName;
                    }
                }

                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
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
