
using System.Data.Entity;

using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using OnData.PruebaTecnicaHDCBA.Context;
using OnData.PruebaTecnicaHDCBA.Models;
using OnData.PruebaTecnicaHDCBA.Helpers;

namespace OnData.PruebaTecnicaHDCBA.Controllers
{
    public class ContainersController : Controller
    {
        private StoreContext db = new StoreContext();

        
        public async Task<ActionResult> Index()
        {

            //var containers = db.containers.OrderBy(x => x.name)
            //    .Skip((page - 1) * RegisterPerPage)
            //    .Take(RegisterPerPage).ToList();

            //var totalRegister = db.containers.Count();


            //var container = containers;
            
            
               
            return View(await db.containers.ToListAsync());

        }

        // GET: Containers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            containers containers = await db.containers.FindAsync(id);
            if (containers == null)
            {
                return HttpNotFound();
            }
            var p = ToView(containers);
            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Details(containerView container)
        {
            
            await MailHelper.SendMail(container.email, "Porta","gracias");
            if (ModelState.IsValid)
            {
                db.Entry(container).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Containers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(containerView view)
        {
            if (ModelState.IsValid)
            {

                var pic = string.Empty;
                var folder = "~/Content/Images";

                if (view.LogoFile != null)
                {
                    pic = FilesHelpers.UploadPhoto(view.LogoFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                    view.type_container_id = 1;
                }

                var container = ToContainer(view);
                
                container.image = pic;
                db.containers.Add(container);
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Index"));
            }

            return View(view);


        }

        private containers ToContainer(containerView view)
        {
            return new containers
            {
                //containers_categories = view.containers_categories,
                name= view.name,
                content = view.content,
                description = view.description,
                image = view.image,
                id = view.id,
                type_container_id = view.type_container_id,
            };
        }

        private containerView ToView(containers item)
        {
            return new containerView
            {
                //containers_categories = item.containers_categories,
                name = item.name,
                content = item.content,
                description = item.description,
                image = item.image,
                id = item.id,
                type_container_id = item.type_container_id,
            };
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            containers containers = await db.containers.FindAsync(id);
            if (containers == null)
            {
                return HttpNotFound();
            }
            return View(containers);
        }

        // POST: Containers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,description,content")] containers containers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(containers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(containers);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            containers containers = await db.containers.FindAsync(id);
            if (containers == null)
            {
                return HttpNotFound();
            }
            return View(containers);
        }

        // POST: Containers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            containers containers = await db.containers.FindAsync(id);
            db.containers.Remove(containers);
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
