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
    public class IRAAccountsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: IRAAccounts
        public ActionResult Index()
        {
            return View(db.IRAAccounts.ToList());
        }

        // GET: IRAAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRAAccount iRAAccount = db.IRAAccounts.Find(id);
            if (iRAAccount == null)
            {
                return HttpNotFound();
            }
            return View(iRAAccount);
        }

        // GET: IRAAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IRAAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IRAAccountID,AccountNumber,AccountBalance,AccountName")] IRAAccount iRAAccount)
        {
            if (ModelState.IsValid)
            {
                db.IRAAccounts.Add(iRAAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iRAAccount);
        }

        // GET: IRAAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRAAccount iRAAccount = db.IRAAccounts.Find(id);
            if (iRAAccount == null)
            {
                return HttpNotFound();
            }
            return View(iRAAccount);
        }

        // POST: IRAAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IRAAccountID,AccountNumber,AccountBalance,AccountName")] IRAAccount iRAAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iRAAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iRAAccount);
        }

        // GET: IRAAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRAAccount iRAAccount = db.IRAAccounts.Find(id);
            if (iRAAccount == null)
            {
                return HttpNotFound();
            }
            return View(iRAAccount);
        }

        // POST: IRAAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IRAAccount iRAAccount = db.IRAAccounts.Find(id);
            db.IRAAccounts.Remove(iRAAccount);
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
