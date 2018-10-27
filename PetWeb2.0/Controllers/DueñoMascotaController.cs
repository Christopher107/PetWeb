using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetWeb2._0.Models;

namespace PetWeb2._0.Controllers
{
    public class DueñoMascotaController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: DueñoMascota
        public ActionResult Index()
        {
            return View(db.DueñoMascota.ToList());
        }

        // GET: DueñoMascota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DueñoMascota dueñoMascota = db.DueñoMascota.Find(id);
            if (dueñoMascota == null)
            {
                return HttpNotFound();
            }
            return View(dueñoMascota);
        }

        // GET: DueñoMascota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DueñoMascota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rut,Correo")] DueñoMascota dueñoMascota)
        {
            if (ModelState.IsValid)
            {
                db.DueñoMascota.Add(dueñoMascota);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            return PartialView(dueñoMascota);
        }

        // GET: DueñoMascota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DueñoMascota dueñoMascota = db.DueñoMascota.Find(id);
            if (dueñoMascota == null)
            {
                return HttpNotFound();
            }
            return View(dueñoMascota);
        }

        // POST: DueñoMascota/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rut,Correo")] DueñoMascota dueñoMascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dueñoMascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dueñoMascota);
        }

        // GET: DueñoMascota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DueñoMascota dueñoMascota = db.DueñoMascota.Find(id);
            if (dueñoMascota == null)
            {
                return HttpNotFound();
            }
            return View(dueñoMascota);
        }

        // POST: DueñoMascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DueñoMascota dueñoMascota = db.DueñoMascota.Find(id);
            db.DueñoMascota.Remove(dueñoMascota);
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
