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
    public class Type_containersController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Type_containers
        public async Task<ActionResult> Index()
        {
            return View(await db.type_containers.ToListAsync());
        }

        // GET: Type_containers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_containers type_containers = await db.type_containers.FindAsync(id);
            if (type_containers == null)
            {
                return HttpNotFound();
            }
            return View(type_containers);
        }

        // GET: Type_containers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Type_containers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,type")] type_containers type_containers)
        {
            if (ModelState.IsValid)
            {
                db.type_containers.Add(type_containers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(type_containers);
        }

        // GET: Type_containers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_containers type_containers = await db.type_containers.FindAsync(id);
            if (type_containers == null)
            {
                return HttpNotFound();
            }
            return View(type_containers);
        }

        // POST: Type_containers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,type")] type_containers type_containers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_containers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(type_containers);
        }

        // GET: Type_containers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_containers type_containers = await db.type_containers.FindAsync(id);
            if (type_containers == null)
            {
                return HttpNotFound();
            }
            return View(type_containers);
        }

        // POST: Type_containers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            type_containers type_containers = await db.type_containers.FindAsync(id);
            db.type_containers.Remove(type_containers);
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
