using OnData.PruebaTecnicaHDCBA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnData.PruebaTecnicaHDCBA.Controllers
{
    public class GenericController : Controller
    {
        private StoreContext db = new StoreContext();

        public JsonResult GetCategories()
        {
            var categories = db.categories.ToList();
            return Json(categories);
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