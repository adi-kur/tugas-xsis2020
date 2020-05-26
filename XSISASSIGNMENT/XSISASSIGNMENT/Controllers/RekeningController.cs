using Repo.Xsis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Xsis;

namespace XSISASSIGNMENT.Controllers
{
    public class RekeningController : Controller
    {
        // GET: Rekening
        public ActionResult Index()
        {
            List<VMRekening> data = RepoRekening.GetALL();
            return View(data);
            
        }
    }
}