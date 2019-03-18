using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoicesManager.Models;
using System.Net;
using System.Data.Entity;

namespace InvoicesManager.Controllers
{
    public class InvoiceItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvoiceItem
        public PartialViewResult Index(int id)
        {
            var invoiceItems = db.InvoiceItems.Where(i => i.InvoiceId == id).ToList();

            return PartialView("_Index",invoiceItems);
        }

        // GET: InvoiceItem
        public PartialViewResult PrintIndex(int id)
        {
            var invoiceItems = db.InvoiceItems.Where(i => i.InvoiceId == id).ToList();

            return PartialView("_PrintIndex", invoiceItems);
        }


        // GET: Create
        public ActionResult Create(int InvoiceId)
        {

            var invoiceItem = new InvoiceItem()
            {
                InvoiceId = InvoiceId
            };

            return View(invoiceItem);
        }

        // POST: InvoiceItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceItem invoiceItem)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceItems.Add(invoiceItem);
                db.SaveChanges();

                return RedirectToAction("Edit", "Invoices", new { id = invoiceItem.InvoiceId });

            }
            //return RedirectToAction("Create", "InvoiceItems", new { InvoiceId = invoiceItem.InvoiceId });
            return View(invoiceItem);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceItem invoiceItem = db.InvoiceItems.Find(id);
            if (invoiceItem == null)
            {
                return HttpNotFound();
            }
            return View(invoiceItem);
        }

        // POST: InvoiceItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvoiceItem invoiceItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Invoices", new { id = invoiceItem.InvoiceId });
            }
            return View(invoiceItem);
        }

        // GET: InvoiceItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceItem invoiceItem = db.InvoiceItems.Find(id);
            if (invoiceItem == null)
            {
                return HttpNotFound();
            }
            return View(invoiceItem);
        }

        // POST: InvoiceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceItem invoiceItem = db.InvoiceItems.Find(id);
            db.InvoiceItems.Remove(invoiceItem);
            db.SaveChanges();
            return RedirectToAction("Edit","Invoices", new { id=invoiceItem.InvoiceId});
        }
    }
}