using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvoicesManager.Models;

namespace InvoicesManager.Controllers
{
    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Company).Include(i => i.Customer);
            return View(invoices.ToList().OrderByDescending(i =>i.IssueDate));
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,CompanyId,CurrentMonthId,IssueDate")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                CalculateInvoiceNumber(invoice);

                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", invoice.CompanyId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", invoice.CustomerId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", invoice.CompanyId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", invoice.CustomerId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,CompanyId,CurrentMonthId,IssueDate")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", invoice.CompanyId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", invoice.CustomerId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void CalculateInvoiceNumber(Invoice invoice)
        {
            try
            {
                int previousNumber = db.Invoices.Where(i => (i.IssueDate.Month == invoice.IssueDate.Month
            && i.IssueDate.Year == invoice.IssueDate.Year))
                .Max(i => i.CurrentMonthNumber);

                invoice.CurrentMonthNumber = previousNumber + 1000000;
            }
            catch (Exception)
            {
                invoice.CurrentMonthNumber = 1000000 + invoice.IssueDate.Month * 10000 + invoice.IssueDate.Year;
            }
            
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
