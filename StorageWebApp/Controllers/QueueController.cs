using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageModels;

namespace StorageWebApp.Controllers
{
    public class QueueController : Controller
    {
        public ActionResult CreateQueue()
        {
            var output = Util.SessionUtil.GetSessionQueue(HttpContext);
            return View(output);
        }

        public ActionResult InsertMessage()
        {
            var output = Util.SessionUtil.GetSessionQueue(HttpContext);
            return View(output);
        }

        public ActionResult ReadMessage()
        {
            var output = Util.SessionUtil.GetSessionQueue(HttpContext);
            return View(output);
        }

        public ActionResult UpdateMessage()
        {
            var output = Util.SessionUtil.GetSessionQueue(HttpContext);
            return View(output);
        }

        public ActionResult DeleteMessage()
        {
            var output = Util.SessionUtil.GetSessionQueue(HttpContext);
            return View(output);
        }

        [HttpPost("CreateQueuePost")]
        public async Task<ActionResult> CreateQueuePost(QueueInformation queueInformation)
        {
            Util.SessionUtil.SetSessionQueue(queueInformation, HttpContext);
            Library.QueueService queueService = new Library.QueueService();
            queueService. CreateQueue(queueInformation);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("InsertMessagePost")]
        public async Task<ActionResult> InsertMessagePost(QueueInformation queueInformation)
        {
            Util.SessionUtil.SetSessionQueue(queueInformation, HttpContext);
            Library.QueueService queueService = new Library.QueueService();
            queueService.InsertMessage(queueInformation);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("ReadMessagePost")]
        public async Task<ActionResult> ReadMessagePost(QueueInformation queueInformation)
        {
            Util.SessionUtil.SetSessionQueue(queueInformation, HttpContext);
            Library.QueueService queueService = new Library.QueueService();
            string response = queueService.PeekMessage(queueInformation);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("UpdateMessagePost")]
        public async Task<ActionResult> UpdateMessagePost(QueueInformation queueInformation)
        {
            Util.SessionUtil.SetSessionQueue(queueInformation, HttpContext);
            Library.QueueService queueService = new Library.QueueService();
            queueService.UpdateMessage(queueInformation);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("DeleteMessagePost")]
        public async Task<ActionResult> DeleteMessagePost(QueueInformation queueInformation)
        {
            Util.SessionUtil.SetSessionQueue(queueInformation, HttpContext);
            Library.QueueService queueService = new Library.QueueService();
            queueService.DequeueMessage(queueInformation);
            return RedirectToAction("Index", "Home");
        }
    }
}
