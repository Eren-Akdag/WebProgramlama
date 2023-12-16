using cloudscribe.Pagination.Models;
using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hastane.Web.Areas.Admin.Controllers
{

    [Area("admin")]
    public class HastanesController : Controller
    {
        
        private IHastaneInfo _hastaneInfo;

        public HastanesController(IHastaneInfo hastaneInfo)
        {
            _hastaneInfo = hastaneInfo;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_hastaneInfo.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var viewModel = _hastaneInfo.GetHospitalById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(HastaneInfoViewModell vm) 
        {
            _hastaneInfo.UpdateHospitalInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HastaneInfoViewModell vm)
        {
            _hastaneInfo.InsertHospitalInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete (int id)
        {
            _hastaneInfo.DeleteHospitalInfo(id);
            return RedirectToAction("Index");
        }
    }
}
