using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPoliclinicController : ControllerBase
    {
        private readonly IPoliclinicRepo _policlinicRepo;

        public ApiPoliclinicController(IPoliclinicRepo policlinicRepo)
        {
            _policlinicRepo = policlinicRepo;
        }

        // GET: api/Policlinics
        [HttpGet]
        public IEnumerable<Policlinic> GetPoliclinics()
        {
            return _policlinicRepo.GetAll().ToList();
        }

        // GET: api/Policlinics/5
        [HttpGet("{id}")]
        public ActionResult<Policlinic> GetPoliclinic(int id)
        {
            var policlinic = _policlinicRepo.GetAll().FirstOrDefault(p => p.Id == id);

            if (policlinic == null)
            {
                return NotFound();
            }

            return policlinic;
        }

        // PUT: api/Policlinics/5
        [HttpPut("{id}")]
        public IActionResult PutPoliclinic(int id, Policlinic policlinic)
        {
            if (id != policlinic.Id)
            {
                return BadRequest();
            }

            _policlinicRepo.Update(policlinic);
            _policlinicRepo.Save();

            return NoContent();
        }

        // POST: api/Policlinics
        [HttpPost]
        public ActionResult<Policlinic> PostPoliclinic(Policlinic policlinic)
        {
            _policlinicRepo.Add(policlinic);
            _policlinicRepo.Save();

            return CreatedAtAction("GetPoliclinic", new { id = policlinic.Id }, policlinic);
        }

        // DELETE: api/Policlinics/5
        [HttpDelete("{id}")]
        public IActionResult DeletePoliclinic(int id)
        {
            var policlinic = _policlinicRepo.GetAll().FirstOrDefault(p => p.Id == id);
            if (policlinic == null)
            {
                return NotFound();
            }

            _policlinicRepo.Delete(policlinic);
            _policlinicRepo.Save();

            return NoContent();
        }
    }
}
