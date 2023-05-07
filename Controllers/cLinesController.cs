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
    public class cLinesController : Controller
    {
        private Курсова_роботаEntities db = new Курсова_роботаEntities();

        // GET: cLines
        public ActionResult Index()
        {
            var cLine = db.cLine.Include(c => c.vOrder).Include(c => c.cProductType);
            return View(cLine.ToList());
        }

        // GET: cLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cLine cLine = db.cLine.Find(id);
            if (cLine == null)
            {
                return HttpNotFound();
            }
            return View(cLine);
        }

        // GET: cLines/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.vOrder, "Id", "Buyer");
            ViewBag.ProductTypeId = new SelectList(db.cProductType, "Id", "Name");
            return View();
        }

        // POST: cLines/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,OrderId,ProductTypeId")] cLine cLine)
        {
            if (ModelState.IsValid)
            {
                db.cLine.Add(cLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.vOrder, "Id", "Buyer", cLine.OrderId);
            ViewBag.ProductTypeId = new SelectList(db.cProductType, "Id", "Name", cLine.ProductTypeId);
            return View(cLine);
        }

        // GET: cLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cLine cLine = db.cLine.Find(id);
            if (cLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.vOrder, "Id", "Buyer", cLine.OrderId);
            ViewBag.ProductTypeId = new SelectList(db.cProductType, "Id", "Name", cLine.ProductTypeId);
            return View(cLine);
        }

        // POST: cLines/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,OrderId,ProductTypeId")] cLine cLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.vOrder, "Id", "Buyer", cLine.OrderId);
            ViewBag.ProductTypeId = new SelectList(db.cProductType, "Id", "Name", cLine.ProductTypeId);
            return View(cLine);
        }

        // GET: cLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cLine cLine = db.cLine.Find(id);
            if (cLine == null)
            {
                return HttpNotFound();
            }
            return View(cLine);
        }

        // POST: cLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cLine cLine = db.cLine.Find(id);
            db.cLine.Remove(cLine);
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
