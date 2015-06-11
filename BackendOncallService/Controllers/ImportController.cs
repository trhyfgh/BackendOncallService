using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackendOncallService.Models;
using System.Data.OleDb;


namespace BackendOncallService.Controllers
{
    public class ImportController : Controller
    {
        private BackendOncallServiceContext db = new BackendOncallServiceContext();

        // GET: Import
        public ActionResult Index()
        {
            return View(db.OncallCells.ToList());
        }

        // GET: Import/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OncallCell oncallCell = db.OncallCells.Find(id);
            if (oncallCell == null)
            {
                return HttpNotFound();
            }
            return View(oncallCell);
        }

        // GET: Import/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Import/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OncallName,OncallShift,OncallDate")] OncallCell oncallCell)
        {
            if (ModelState.IsValid)
            {
                db.OncallCells.Add(oncallCell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(oncallCell);
        }

        // GET: Import/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OncallCell oncallCell = db.OncallCells.Find(id);
            if (oncallCell == null)
            {
                return HttpNotFound();
            }
            return View(oncallCell);
        }

        // POST: Import/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OncallName,OncallShift,OncallDate")] OncallCell oncallCell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oncallCell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oncallCell);
        }

        // GET: Import/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OncallCell oncallCell = db.OncallCells.Find(id);
            if (oncallCell == null)
            {
                return HttpNotFound();
            }
            
            return View(oncallCell);
        }

        // POST: Import/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OncallCell oncallCell = db.OncallCells.Find(id);
            db.OncallCells.Remove(oncallCell);
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

        public void GetOncallFile(string path)
        {
            string filePath = path;
        }

        public ArrayList FetchOncallFile(string path){

            ArrayList al = new ArrayList();
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="+path+";Extended Properties=Excel15.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
           
            DataTable oncallTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[]{null,null,null,"TABLE"});
            conn.Close();
            foreach(DataRow oncallItem in oncallTable.Rows)
            {
                al.Add(dr[2])
            }

            String strExcel = "";
            OleDbDataAdapter eAdapter = null;
            DataSet ds =new DataSet();
            
            strExcel = "Select * from [oncalllist$]";
            eAdapter = new OleDbDataAdapter(strExcel, strConn);
            eAdapter.Fill(ds, "table1");
            

        }
        
    }
}
