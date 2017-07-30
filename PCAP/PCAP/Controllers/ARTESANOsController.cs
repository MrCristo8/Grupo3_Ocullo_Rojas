using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCAP.Models;
using System.Web.UI.WebControls;

namespace PCAP.Controllers
{
    public class ARTESANOsController : Controller
    {
        private PCAPDBEntities db = new PCAPDBEntities();

        // GET: ARTESANOs
        public ActionResult Index()
        {
            var aRTESANO = db.ARTESANO.Include(a => a.DISCIPLINA).Include(a => a.DIRECCION);
            return View(aRTESANO.ToList());
        }

        // GET: ARTESANOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTESANO aRTESANO = db.ARTESANO.Find(id);
            if (aRTESANO == null)
            {
                return HttpNotFound();
            }
            return View(aRTESANO);
        }

        // GET: ARTESANOs/Create
        public ActionResult Create()
        {
            ViewBag.CODIGODISCIPLINA = new SelectList(db.DISCIPLINA, "CODIGODISCIPLINA", "NOMBREDISCIPLINA");
            ViewBag.CODIGODIRECCION = new SelectList(db.DIRECCION, "CODIGODIRECCION", "SECTORDIRECCION");
            return View();
        }

        // POST: ARTESANOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGOARTESANO,CODIGODIRECCION,CODIGODISCIPLINA,CI_RUC_RISE,NOMBREARTESANO,APELLIDOARTESANO,FECHANACIMIENTO,NUMEROAFILIACION,BARRIOARTESANO,TELEFONOTALLERARTESANO,TELEFONODOMICILIOARTESANO,TELEFONOPERSONALARTESANO,CORREOARTESANO,RAZONSOCIAL,ACTIVIDADNEGOCIO,RESENAHISTORICAMARCA,LOGOMARCA,ACUERTOINTERMINISTERIAL,PATENTEMUNICIPAL")] ARTESANO aRTESANO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Validacion.ValidarCedula(aRTESANO.CI_RUC_RISE))
                    {
                        db.ARTESANO.Add(aRTESANO);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error en el documento de identificación");
                    }
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("Error en el ingreso de datos: ", e.Message);
                }
            }

            ViewBag.CODIGODISCIPLINA = new SelectList(db.DISCIPLINA, "CODIGODISCIPLINA", "NOMBREDISCIPLINA", aRTESANO.CODIGODISCIPLINA);
            ViewBag.CODIGODIRECCION = new SelectList(db.DIRECCION, "CODIGODIRECCION", "SECTORDIRECCION", aRTESANO.CODIGODIRECCION);
            return View(aRTESANO);
        }

        // GET: ARTESANOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTESANO aRTESANO = db.ARTESANO.Find(id);
            if (aRTESANO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGODISCIPLINA = new SelectList(db.DISCIPLINA, "CODIGODISCIPLINA", "NOMBREDISCIPLINA", aRTESANO.CODIGODISCIPLINA);
            ViewBag.CODIGODIRECCION = new SelectList(db.DIRECCION, "CODIGODIRECCION", "SECTORDIRECCION", aRTESANO.CODIGODIRECCION);
            return View(aRTESANO);
        }

        // POST: ARTESANOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGOARTESANO,CODIGODIRECCION,CODIGODISCIPLINA,CI_RUC_RISE,NOMBREARTESANO,APELLIDOARTESANO,FECHANACIMIENTO,NUMEROAFILIACION,BARRIOARTESANO,TELEFONOTALLERARTESANO,TELEFONODOMICILIOARTESANO,TELEFONOPERSONALARTESANO,CORREOARTESANO,RAZONSOCIAL,ACTIVIDADNEGOCIO,RESENAHISTORICAMARCA,LOGOMARCA,ACUERTOINTERMINISTERIAL,PATENTEMUNICIPAL")] ARTESANO aRTESANO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTESANO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGODISCIPLINA = new SelectList(db.DISCIPLINA, "CODIGODISCIPLINA", "NOMBREDISCIPLINA", aRTESANO.CODIGODISCIPLINA);
            ViewBag.CODIGODIRECCION = new SelectList(db.DIRECCION, "CODIGODIRECCION", "SECTORDIRECCION", aRTESANO.CODIGODIRECCION);
            return View(aRTESANO);
        }

        // GET: ARTESANOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTESANO aRTESANO = db.ARTESANO.Find(id);
            if (aRTESANO == null)
            {
                return HttpNotFound();
            }
            return View(aRTESANO);
        }

        // POST: ARTESANOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTESANO aRTESANO = db.ARTESANO.Find(id);
            db.ARTESANO.Remove(aRTESANO);
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

        //Imagen
        [HttpPost]
        public ActionResult AddImage(Image image)
        {
            return View();
        }
    }
}
