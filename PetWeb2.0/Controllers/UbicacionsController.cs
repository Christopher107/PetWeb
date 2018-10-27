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
    public class UbicacionsController : Controller
    {
        private PetWebEntities db = new PetWebEntities();

        // GET: Ubicacions
        public ActionResult Index()
        {
            var ubicacion = db.Ubicacion.Include(u => u.DueñoMascota).Include(u => u.Sucursal1);
            return View(ubicacion.ToList());
        }

        // GET: Ubicacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            return View(ubicacion);
        }

        // GET: Ubicacions/Create
        public ActionResult Create()
        {
            ViewBag.RutCliente = new SelectList(db.DueñoMascota, "Id", "Correo");
            ViewBag.IdCliente = new SelectList(db.DueñoMascota, "Id", "Correo");
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Usuario");
            return View();
        }

        // POST: Ubicacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sucursal,IdCliente,RutCliente,Region,Ciudad,Calle,Numero")] Ubicacion ubicacion)
        {                                 
            {
                db.Ubicacion.Add(ubicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RutCliente = new SelectList(db.DueñoMascota, "Id", "Correo", ubicacion.IdCliente);
            ViewBag.IdCliente = new SelectList(db.DueñoMascota, "Id", "Correo", ubicacion.IdCliente);
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Usuario", ubicacion.Sucursal);
            return PartialView(ubicacion);
        }

        // GET: Ubicacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.DueñoMascota, "Id", "Correo", ubicacion.IdCliente);
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Usuario", ubicacion.Sucursal);
            return View(ubicacion);
        }

        // POST: Ubicacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sucursal,IdCliente,RutCliente,Region,Ciudad,Calle,Numero")] Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ubicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.DueñoMascota, "Id", "Correo", ubicacion.IdCliente);
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Usuario", ubicacion.Sucursal);
            return View(ubicacion);
        }

        // GET: Ubicacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            return View(ubicacion);
        }

        // POST: Ubicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            db.Ubicacion.Remove(ubicacion);
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
