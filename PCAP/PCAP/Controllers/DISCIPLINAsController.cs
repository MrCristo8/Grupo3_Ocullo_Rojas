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
    public class DISCIPLINAsController : Controller
    {
        private PCAPDBEntities db = new PCAPDBEntities();

        // GET: DISCIPLINAs
        public ActionResult Index()
        {
            return View(db.DISCIPLINA.ToList());
        }

        // GET: DISCIPLINAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCIPLINA dISCIPLINA = db.DISCIPLINA.Find(id);
            if (dISCIPLINA == null)
            {
                return HttpNotFound();
            }
            return View(dISCIPLINA);
        }

        // GET: DISCIPLINAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DISCIPLINAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGODISCIPLINA,NOMBREDISCIPLINA")] DISCIPLINA dISCIPLINA)
        {
            if (ModelState.IsValid)
            {
                db.DISCIPLINA.Add(dISCIPLINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dISCIPLINA);
        }

        // GET: DISCIPLINAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCIPLINA dISCIPLINA = db.DISCIPLINA.Find(id);
            if (dISCIPLINA == null)
            {
                return HttpNotFound();
            }
            return View(dISCIPLINA);
        }

        // POST: DISCIPLINAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGODISCIPLINA,NOMBREDISCIPLINA")] DISCIPLINA dISCIPLINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISCIPLINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dISCIPLINA);
        }

        // GET: DISCIPLINAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCIPLINA dISCIPLINA = db.DISCIPLINA.Find(id);
            if (dISCIPLINA == null)
            {
                return HttpNotFound();
            }
            return View(dISCIPLINA);
        }

        // POST: DISCIPLINAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DISCIPLINA dISCIPLINA = db.DISCIPLINA.Find(id);
            db.DISCIPLINA.Remove(dISCIPLINA);
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
