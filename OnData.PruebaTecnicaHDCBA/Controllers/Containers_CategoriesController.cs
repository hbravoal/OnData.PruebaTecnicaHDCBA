using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnData.PruebaTecnicaHDCBA.Context;
using OnData.PruebaTecnicaHDCBA.Models;

namespace OnData.PruebaTecnicaHDCBA.Controllers
{
    public class Containers_CategoriesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Containers_Categories
        public async Task<ActionResult> Index()
        {
            return View(await db.containers_categories.ToListAsync());
        }

        // GET: Containers_Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            containers_categories containers_categories = await db.containers_categories.FindAsync(id);
            if (containers_categories == null)
            {
                return HttpNotFound();
            }
            return View(containers_categories);
        }

        // GET: Containers_Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Containers_Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,category_id,container_id")] containers_categories containers_categories)
        {
            if (ModelState.IsValid)
            {
                db.containers_categories.Add(containers_categories);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(containers_categories);
        }

        // GET: Containers_Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            containers_categories containers_categories = await db.containers_categories.FindAsync(id);
            if (containers_categories == null)
            {
                return HttpNotFound();
            }
            return View(containers_categories);
        }

        // POST: Containers_Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,category_id,container_id")] containers_categories containers_categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(containers_categories).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(containers_categories);
        }

        // GET: Containers_Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            containers_categories containers_categories = await db.containers_categories.FindAsync(id);
            if (containers_categories == null)
            {
                return HttpNotFound();
            }
            return View(containers_categories);
        }

        // POST: Containers_Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            containers_categories containers_categories = await db.containers_categories.FindAsync(id);
            db.containers_categories.Remove(containers_categories);
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
