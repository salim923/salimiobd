using System.Runtime.InteropServices;
using OBD.Data;
using OBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OBD.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("details/{id}")]
        public  async Task<IActionResult> Details(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] User model)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }



            user.Username = model.Username;
            user.Email = model.Email;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
           

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok(user);



        }

            // POST: UserController/Edit/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
