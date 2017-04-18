using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team3FinalProject.Models;

namespace Team3FinalProject.Controllers
{
    public class SavingAccountsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: SavingAccounts
        public ActionResult Index()
        {
            return View(db.SavingAcocunts.ToList());
        }

        // GET: SavingAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingAccount savingAccount = db.SavingAcocunts.Find(id);
            if (savingAccount == null)
            {
                return HttpNotFound();
            }
            return View(savingAccount);
        }

        // GET: SavingAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SavingAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SavingAccountID,AccountNumber,AccountBalance,AccountName")] SavingAccount savingAccount)
        {
            if (ModelState.IsValid)
            {
                db.SavingAcocunts.Add(savingAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(savingAccount);
        }

        // GET: SavingAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingAccount savingAccount = db.SavingAcocunts.Find(id);
            if (savingAccount == null)
            {
                return HttpNotFound();
            }
            return View(savingAccount);
        }

        // POST: SavingAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SavingAccountID,AccountNumber,AccountBalance,AccountName")] SavingAccount savingAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(savingAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(savingAccount);
        }

        // GET: SavingAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingAccount savingAccount = db.SavingAcocunts.Find(id);
            if (savingAccount == null)
            {
                return HttpNotFound();
            }
            return View(savingAccount);
        }

        // POST: SavingAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SavingAccount savingAccount = db.SavingAcocunts.Find(id);
            db.SavingAcocunts.Remove(savingAccount);
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
