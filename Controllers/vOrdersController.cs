using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class vOrdersController : Controller
    {
        private Курсова_роботаEntities db = new Курсова_роботаEntities();

        // GET: vOrders
        public ActionResult Index()
        {
            return View(db.vOrder.ToList());
        }

        // GET: vOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vOrder vOrder = db.vOrder.Find(id);
            if (vOrder == null)
            {
                return HttpNotFound();
            }
            return View(vOrder);
        }

        // GET: vOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Buyer,ShipmentDate")] vOrder vOrder)
        {
            if (ModelState.IsValid)
            {
                db.vOrder.Add(vOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vOrder);
        }

        // GET: vOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vOrder vOrder = db.vOrder.Find(id);
            if (vOrder == null)
            {
                return HttpNotFound();
            }
            return View(vOrder);
        }

        // POST: vOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Buyer,ShipmentDate")] vOrder vOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vOrder);
        }

        // GET: vOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vOrder vOrder = db.vOrder.Find(id);
            if (vOrder == null)
            {
                return HttpNotFound();
            }
            return View(vOrder);
        }

        // POST: vOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vOrder vOrder = db.vOrder.Find(id);
            db.vOrder.Remove(vOrder);
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
