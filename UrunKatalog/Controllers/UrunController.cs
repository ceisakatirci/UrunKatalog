using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UrunKatalog.Models;

namespace UrunKatalog.Controllers
{
    public class UrunController : Controller
    {
        private UrunKatalogContext db = new UrunKatalogContext();

        // GET: Uruns
        public async Task<ActionResult> Index()
        {
            return View(await db.Uruns.ToListAsync());
        }

        public ActionResult TekUrun()
        {
            return View();
        }

        // GET: Uruns/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = await db.Uruns.FindAsync(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // GET: Uruns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uruns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Uruns.Add(urun);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(urun);
        }

        // GET: Uruns/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = await db.Uruns.FindAsync(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Uruns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(urun);
        }

        // GET: Uruns/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = await db.Uruns.FindAsync(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Uruns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Urun urun = await db.Uruns.FindAsync(id);
            db.Uruns.Remove(urun);
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
