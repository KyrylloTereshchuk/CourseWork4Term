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
    public class cProductTypesController : Controller
    {
        private Курсова_роботаEntities db = new Курсова_роботаEntities();

        // GET: cProductTypes
        public ActionResult Index()
        {
            return View(db.cProductType.ToList());
        }

        // GET: cProductTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cProductType cProductType = db.cProductType.Find(id);
            if (cProductType == null)
            {
                return HttpNotFound();
            }
            return View(cProductType);
        }

        // GET: cProductTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cProductTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price")] cProductType cProductType)
        {
            if (ModelState.IsValid)
            {
                db.cProductType.Add(cProductType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cProductType);
        }

        // GET: cProductTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cProductType cProductType = db.cProductType.Find(id);
            if (cProductType == null)
            {
                return HttpNotFound();
            }
            return View(cProductType);
        }

        // POST: cProductTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price")] cProductType cProductType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cProductType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cProductType);
        }

        // GET: cProductTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cProductType cProductType = db.cProductType.Find(id);
            if (cProductType == null)
            {
                return HttpNotFound();
            }
            return View(cProductType);
        }

        // POST: cProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cProductType cProductType = db.cProductType.Find(id);
            db.cProductType.Remove(cProductType);
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
