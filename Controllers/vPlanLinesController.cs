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
    public class vPlanLinesController : Controller
    {
        private Курсова_роботаEntities db = new Курсова_роботаEntities();

        // GET: vPlanLines
        public ActionResult Index()
        {
            var vPlanLine = db.vPlanLine.Include(v => v.cProductType);
            return View(vPlanLine.ToList());
        }

        // GET: vPlanLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vPlanLine vPlanLine = db.vPlanLine.Find(id);
            if (vPlanLine == null)
            {
                return HttpNotFound();
            }
            return View(vPlanLine);
        }

        // GET: vPlanLines/Create
        public ActionResult Create()
        {
            ViewBag.ProductTypeId = new SelectList(db.cProductType, "Id", "Name");
            return View();
        }

        // POST: vPlanLines/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReservedShipment,ShipmentBuyersOrders,Production,EstimatedStockBalance,AvailablePromise,C_Date,ProductTypeId")] vPlanLine vPlanLine)
        {
            if (ModelState.IsValid)
            {
                db.vPlanLine.Add(vPlanLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductTypeId = new SelectList(db.cProductType, "Id", "Name", vPlanLine.ProductTypeId);
            return View(vPlanLine);
        }

        // GET: vPlanLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vPlanLine vPlanLine = db.vPlanLine.Find(id);
            if (vPlanLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeId = new SelectList(db.cProductType, "Id", "Name", vPlanLine.ProductTypeId);
            return View(vPlanLine);
        }

        // POST: vPlanLines/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReservedShipment,ShipmentBuyersOrders,Production,EstimatedStockBalance,AvailablePromise,C_Date,ProductTypeId")] vPlanLine vPlanLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vPlanLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductTypeId = new SelectList(db.cProductType, "Id", "Name", vPlanLine.ProductTypeId);
            return View(vPlanLine);
        }

        // GET: vPlanLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vPlanLine vPlanLine = db.vPlanLine.Find(id);
            if (vPlanLine == null)
            {
                return HttpNotFound();
            }
            return View(vPlanLine);
        }

        // POST: vPlanLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vPlanLine vPlanLine = db.vPlanLine.Find(id);
            db.vPlanLine.Remove(vPlanLine);
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
