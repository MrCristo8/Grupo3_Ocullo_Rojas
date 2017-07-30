using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCAP.Models;

namespace PCAP.Controllers
{
    public class DIRECCIONsController : Controller
    {
        private PCAPDBEntities db = new PCAPDBEntities();

        // GET: DIRECCIONs
        public ActionResult Index()
        {
            return View(db.DIRECCION.ToList());
        }

        // GET: DIRECCIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null)
            {
                return HttpNotFound();
            }
            return View(dIRECCION);
        }

        // GET: DIRECCIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DIRECCIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGODIRECCION,SECTORDIRECCION,BARRIODIRECCION,CALLEPRINCIPAL,CALLESECUNDARIA")] DIRECCION dIRECCION)
        {
            if (ModelState.IsValid)
            {
                db.DIRECCION.Add(dIRECCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dIRECCION);
        }

        // GET: DIRECCIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null)
            {
                return HttpNotFound();
            }
            return View(dIRECCION);
        }

        // POST: DIRECCIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGODIRECCION,SECTORDIRECCION,BARRIODIRECCION,CALLEPRINCIPAL,CALLESECUNDARIA")] DIRECCION dIRECCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIRECCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dIRECCION);
        }

        // GET: DIRECCIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null)
            {
                return HttpNotFound();
            }
            return View(dIRECCION);
        }

        // POST: DIRECCIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            db.DIRECCION.Remove(dIRECCION);
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
