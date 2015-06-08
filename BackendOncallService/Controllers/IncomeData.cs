﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackendOncallService.Models;

namespace BackendOncallService.Controllers
{
    public class IncomeData : Controller
    {
        private BackendOncallServiceContext db = new BackendOncallServiceContext();

        // GET: IncomeData
        public async Task<ActionResult> Index()
        {
            return View(await db.OncallCells.ToListAsync());
        }

        // GET: IncomeData/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OncallCell oncallCell = await db.OncallCells.FindAsync(id);
            if (oncallCell == null)
            {
                return HttpNotFound();
            }
            return View(oncallCell);
        }

        // GET: IncomeData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncomeData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OncallName,OncallShift,OncallDate")] OncallCell oncallCell)
        {
            if (ModelState.IsValid)
            {
                db.OncallCells.Add(oncallCell);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oncallCell);
        }

        // GET: IncomeData/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OncallCell oncallCell = await db.OncallCells.FindAsync(id);
            if (oncallCell == null)
            {
                return HttpNotFound();
            }
            return View(oncallCell);
        }

        // POST: IncomeData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OncallName,OncallShift,OncallDate")] OncallCell oncallCell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oncallCell).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oncallCell);
        }

        // GET: IncomeData/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OncallCell oncallCell = await db.OncallCells.FindAsync(id);
            if (oncallCell == null)
            {
                return HttpNotFound();
            }
            return View(oncallCell);
        }

        // POST: IncomeData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OncallCell oncallCell = await db.OncallCells.FindAsync(id);
            db.OncallCells.Remove(oncallCell);
            await db.SaveChangesAsync();
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
