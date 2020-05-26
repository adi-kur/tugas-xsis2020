using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Xsis;
using Repo.Xsis;

namespace XSISASSIGNMENT.Controllers
{
    public class KreditRumahController : Controller
    {
        // GET: KreditRumah
        public ActionResult Index()
        {
            List<VMKreditRumah> data = RepoKreditRumah.GetALL();
            return View(data);

        }

        public ActionResult Create(string noRek)
        {
            ViewBag.NoRek = noRek;

            return PartialView("Create");
        }

        [HttpPost]
        public ActionResult Create(VMKreditRumah data)
        {
            string result = RepoKreditRumah.Create(data);

            if(result == "ok")
            {
                return Json(new { message = "Berhasil", data = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", "KreditRumah");

            }

        }

        public ActionResult HitungAngsuran(long id)
        {
            List<VM_Angsuran> result = RepoKreditRumah.HitungAngsuran(id);

            return View("View", result);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            string result = RepoKreditRumah.HapusData(id);
            if (result == "ok")
            {
                return RedirectToAction("Index", "KreditRumah");
            }
            else
            {
                return Json(new { message = "Gagal", data = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}