using Hastane.Model;
using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace Hastane.Web.Areas.Admin.Controllers
{

    [Area("admin")]

    public class ContactsController : Controller
    {

        private IContactService _contact;
        private IHastaneInfo _hastaneInfo;


        public ContactsController(IContactService contact, IHastaneInfo hastaneInfo)
        {
             _contact = contact;
            _hastaneInfo = hastaneInfo;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_contact.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.hospital = new SelectList(_hastaneInfo.GetAll(), "Id", "Name");
            var viewModel = _contact.GetContactById(id);
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(ContactViewModel vm) 
        {
            _contact.UpdateContact(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() 
        {
            ViewBag.hospital = new SelectList(_hastaneInfo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel vm) 
        {
            _contact.InsertContact(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            _contact.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
