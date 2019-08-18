using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.Models.TShirts;

namespace Shop_T.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Designer()
        {
            return View();
        }
        [HttpPost("UploadFiles")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(PictureViewModel picture, IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return View(picture);
            }
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\items", fileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileSteam);
                }
                picture.Image = fileName;
            }

           // _context.Add(item);
           // await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Designer));
        }
        public IActionResult Item()
        {
            //TODO: make get a tshirt from the db and render the page
            return View();
        }
    }

   
    // process uploaded files
    // Don't rely on or trust the FileName property without validation.





}