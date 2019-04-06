using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCventa.Models;

namespace MVCventa.Controllers
{
    public class VentsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Vents
        public ActionResult Index()
        {
            return View(db.Vents.ToList());
        }

        // GET: Vents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vent vent = db.Vents.Find(id);
            if (vent == null)
            {
                return HttpNotFound();
            }
            return View(vent);
        }

        // GET: Vents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vents/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaId,fecha,Producto,Cantidad,entrega")] Vent vent)
        {
            if (ModelState.IsValid)
            {
                db.Vents.Add(vent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vent);
        }

        // GET: Vents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vent vent = db.Vents.Find(id);
            if (vent == null)
            {
                return HttpNotFound();
            }
            return View(vent);
        }

        // POST: Vents/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaId,fecha,Producto,Cantidad,entrega")] Vent vent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vent);
        }

        // GET: Vents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vent vent = db.Vents.Find(id);
            if (vent == null)
            {
                return HttpNotFound();
            }
            return View(vent);
        }

        // POST: Vents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vent vent = db.Vents.Find(id);
            db.Vents.Remove(vent);
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
