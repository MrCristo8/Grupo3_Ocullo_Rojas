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
    public class PEDIDOsController : Controller
    {
        private PCAPDBEntities db = new PCAPDBEntities();

        // GET: PEDIDOs
        public ActionResult Index()
        {
            var pEDIDO = db.PEDIDO.Include(p => p.CLIENTE).Include(p => p.PRODUCTO);
            return View(pEDIDO.ToList());
        }

        // GET: PEDIDOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pEDIDO = db.PEDIDO.Find(id);
            if (pEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(pEDIDO);
        }

        // GET: PEDIDOs/Create
        public ActionResult Create()
        {
            ViewBag.CODIGOCLIENTE = new SelectList(db.CLIENTE, "CODIGOCLIENTE", "NOMBRECLIENTE");
            ViewBag.CODIGOPRODUCTO = new SelectList(db.PRODUCTO, "CODIGOPRODUCTO", "NOMBREPRODUCTO");
            return View();
        }

        // POST: PEDIDOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGOPEDIDO,CODIGOCLIENTE,CODIGOPRODUCTO,FECHAPEDIDO,CANTIDADPEDIDO")] PEDIDO pEDIDO)
        {
            CLIENTE client = new CLIENTE();
            PRODUCTO product = new PRODUCTO();
            Email envio = new Email();
            if (ModelState.IsValid)
            {
                try
                {
                    db.PEDIDO.Add(pEDIDO);
                    db.SaveChanges();
                    client = db.CLIENTE.Find(pEDIDO.CODIGOCLIENTE);
                    product = db.PRODUCTO.Find(pEDIDO.CODIGOPRODUCTO);
                    //if (stock.CANTIDADPRODUCTO >= pEDIDO.CANTIDADPEDIDO)
                    //{
                        envio.Nombre = client.NOMBRECLIENTE;
                        envio.Contenido = " <p align=center><b>Se ha realizado un perdido con el sigioente detalle</b></p><br/>" +
                            "Nombre y apellidos del cliente: " + client.NOMBRECLIENTE + " " + client.APELLIDOCLIENTE + "<br/>" +
                            "<pre>Producto seleccionado: " + product.NOMBREPRODUCTO + " \tValor unitario: " + product.PRECIOPRODUCTO + "</pre > <br/>" +
                            "<pre>Cantidad del pedido: " + pEDIDO.CANTIDADPEDIDO + "    \tTotal a pagar: " + Convert.ToInt32(pEDIDO.CANTIDADPEDIDO) * Convert.ToInt32(product.PRECIOPRODUCTO) + "</pre><br/>" +
                            "Para retirar su pedido favor acérquese directamente a la cámara artesanal<br/>Gracias por su compra";
                        envio.enviaEmail(client.CORREOCLIENTE);
                        return RedirectToAction("Index");
                    //}
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Error en el ingreso de datos: ", e.Message);
                }
            }
            Console.WriteLine("Error inesperado");
            ViewBag.CODIGOCLIENTE = new SelectList(db.CLIENTE, "CODIGOCLIENTE", "NOMBRECLIENTE", pEDIDO.CODIGOCLIENTE);
            ViewBag.CODIGOPRODUCTO = new SelectList(db.PRODUCTO, "CODIGOPRODUCTO", "NOMBREPRODUCTO", pEDIDO.CODIGOPRODUCTO);
            return View(pEDIDO);
        }

        // GET: PEDIDOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pEDIDO = db.PEDIDO.Find(id);
            if (pEDIDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGOCLIENTE = new SelectList(db.CLIENTE, "CODIGOCLIENTE", "NOMBRECLIENTE", pEDIDO.CODIGOCLIENTE);
            ViewBag.CODIGOPRODUCTO = new SelectList(db.PRODUCTO, "CODIGOPRODUCTO", "NOMBREPRODUCTO", pEDIDO.CODIGOPRODUCTO);
            return View(pEDIDO);
        }

        // POST: PEDIDOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGOPEDIDO,CODIGOCLIENTE,CODIGOPRODUCTO,FECHAPEDIDO,CANTIDADPEDIDO")] PEDIDO pEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pEDIDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGOCLIENTE = new SelectList(db.CLIENTE, "CODIGOCLIENTE", "NOMBRECLIENTE", pEDIDO.CODIGOCLIENTE);
            ViewBag.CODIGOPRODUCTO = new SelectList(db.PRODUCTO, "CODIGOPRODUCTO", "NOMBREPRODUCTO", pEDIDO.CODIGOPRODUCTO);
            return View(pEDIDO);
        }

        // GET: PEDIDOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pEDIDO = db.PEDIDO.Find(id);
            if (pEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(pEDIDO);
        }

        // POST: PEDIDOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PEDIDO pEDIDO = db.PEDIDO.Find(id);
            db.PEDIDO.Remove(pEDIDO);
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
