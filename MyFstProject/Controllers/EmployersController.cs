using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFstProject.Models;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFstProject.Controllers
{
    [Route("api/[controller]")]
    public class EmployersController : Controller
    {
        EmployerContext db;
        public EmployersController(EmployerContext context)
        {
            this.db = context;
            if (!db.Employers.Any())
            {
                db.Employers.Add(new Employer { Name = "Gryzyshyn Svitlana", Position = "boss", Salary = 20000 });
                db.Employers.Add(new Employer { Name = "Kilchytska Olga", Position = "postman", Salary = 3000 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Employer> Get()
        {
            return db.Employers.ToList();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Employer employer = db.Employers.FirstOrDefault(x => x.Id == id);
            if (employer == null)
                return NotFound();
            return new ObjectResult(employer);
        }


        [HttpPost]
        public IActionResult Post([FromBody]Employer employer)
        {
            if (employer == null)
            {
                return BadRequest();
            }

            db.Employers.Add(employer);
            db.SaveChanges();
            return Ok(employer);
        }


        [HttpPut]
        public IActionResult Put([FromBody]Employer emloyer)
        {
            if (emloyer == null)
            {
                return BadRequest();
            }
            if (!db.Employers.Any(x => x.Id == emloyer.Id))
            {
                return NotFound();
            }

            db.Update(emloyer);
            db.SaveChanges();
            return Ok(emloyer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Employer employer = db.Employers.FirstOrDefault(x => x.Id == id);
            if (employer == null)
            {
                return NotFound();
            }
            db.Employers.Remove(employer);
            db.SaveChanges();
            return Ok(employer);
        }
    }
}
