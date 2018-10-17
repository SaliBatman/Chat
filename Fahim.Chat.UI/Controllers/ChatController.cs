using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fahim.Chat.UpdateDatabase.Model;
using Fahim.Chat.UpdateDatabase.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fahim.Chat.UI.Controllers
{
    public class ChatController : Controller
    {
        private readonly IRepository<Conversation> _conversationRepository;
        public ChatController(IRepository<Conversation> conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }
        public async Task<IActionResult> Index()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Signup", "User");
            //}

           var conversation =  _conversationRepository.GetAll().Where(s=>s.ReceiverId == Guid.Parse("73427083-8C9D-414C-8D83-50E93235B0D9")).GroupBy(s => s.SenderId);
            return View(conversation.ToArray());
        }
    }
}