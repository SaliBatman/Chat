using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fahim.Chat.UI.Models;
using Fahim.Chat.UpdateDatabase.Model;
using Fahim.Chat.UpdateDatabase.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fahim.Chat.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<Users> _usersRepo;
        private readonly IHostingEnvironment _hostingEnvironment;
        public UserController(IRepository<Users> usersRepo , IHostingEnvironment hostingEnvironment)
        {
            _usersRepo = usersRepo;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("signup")]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost("signup")]
        public IActionResult SignUp(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            var user = new Users()
            {
                PhoneNumber = model.PhoneNumber,
                Firsname = model.Firstname,
                Lastname = model.Lastname,
                RegistrationDate = DateTime.Now,
                UserId = Guid.NewGuid(),
                IsLogin = true,
                LastLoginDate = DateTime.Now,
                Username = model.Email

            };
            _usersRepo.Insert(user);
            _usersRepo.SaveToDb();
            return RedirectToAction("Profile" , new { id = user.IdentifierNumber });
        }


        public async  Task<IActionResult> Profile(int id)
        {
            var user = await _usersRepo.FindByIdentifierAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(Users model ,IFormFile[] files)
        {
            var user = await _usersRepo.FindAsync(model.UserId);
            user.About = model.About;
            if (files.Any())
            {
                foreach (var file in files)
                {
                    var fileId = Guid.NewGuid();
                    var extensionType = file.FileName.Split(".").Last();
                    user.Files.Add(new Files()
                    {
                        AddedDate = DateTime.Now,
                        FileId = fileId,
                        FileSize = file.Length,
                        ItemId = user.UserId,
                        MimeType = file.ContentType,
                        OrginalName = file.FileName,
                        StoragePath = $"/storage/image/{fileId}.{extensionType}"
                    });
                    if (file.Length > 0)
                    {
                        var storagePath = Path.Combine(_hostingEnvironment.WebRootPath, @"storage\image");
                        var filePath = Path.Combine(storagePath, fileId.ToString() + $".{extensionType}");
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                }
            }
            _usersRepo.SaveToDb();
            return RedirectToAction("Index","Chat");
        }
    }
}