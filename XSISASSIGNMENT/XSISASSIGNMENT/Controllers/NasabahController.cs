using Repo.Xsis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Xsis;

namespace XSISASSIGNMENT.Controllers
{
    public class NasabahController : Controller
    {
        // GET: Nasabah
        public ActionResult Index()
        {
            List<VMNasabah> data = RepoNasabah.GetALL();
            return View(data);
        }

        public ActionResult Create()
        {
            VMNasabah data = new VMNasabah();
            return View("Create", data);
        }

        [HttpPost]
        public ActionResult Create(VMNasabah Nasabah)
        {
            string result = RepoNasabah.savedata(Nasabah);

            if (result == "ok")
            {
                return Json(new { message = "Berhasil", data = result }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index", "Nasabah");
            }
            else
            {
                return RedirectToAction("Index", "Nasabah");
            }
        }

        public ActionResult Edit(long Nasabah)
        {
            VMNasabah data = RepoNasabah.GetDataByID(Nasabah);

            return View("Edit", data);
        }

        [HttpPost]
        public ActionResult Edit(VMNasabah Nasabah)
        {
            string result = RepoNasabah.editdata(Nasabah);
            if (result == "ok")
            {
                return RedirectToAction("Index", "Nasabah");
            }
            else
            {
                return Json(new { message = "Gagal", data = result }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(long Nasabah)
        {
            string result = RepoNasabah.HapusData(Nasabah);
            if (result == "ok")
            {
                return RedirectToAction("Index", "Nasabah");
            }
            else
            {
                return Json(new { message = "Gagal", data = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}