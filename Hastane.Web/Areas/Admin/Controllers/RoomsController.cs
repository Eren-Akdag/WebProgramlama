using Hastane.Model;
using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace Hastane.Web.Areas.Admin.Controllers
{

    [Area("admin")]

    public class RoomsController : Controller
    {

        private IRoomService _room;
        private IHastaneInfo _hastaneInfo;


        public RoomsController(IRoomService room, IHastaneInfo hastaneInfo)
        {
            _room = room;
            _hastaneInfo = hastaneInfo;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_room.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.hospital = new SelectList(_hastaneInfo.GetAll(), "Id", "Name");
            var viewModel = _room.GetRoomById(id);
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(RoomViewModel vm) 
        {
            _room.UpdateRoom(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() 
        {
            ViewBag.hospital = new SelectList(_hastaneInfo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomViewModel vm) 
        {
            _room.InsertRoom(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
