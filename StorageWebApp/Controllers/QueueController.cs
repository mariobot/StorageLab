using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageModels;

namespace StorageWebApp.Controllers
{
    public class QueueController : Controller
    {
        public const string SessionConnectionString = "_connstring";
        public const string SessionContainer = "_container";

        public StorageInformation memoryStorageInformation { get; set; }

        // GET: StorageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StorageController/Create
        public ActionResult CreateQueue()
        {
            var output = Util.SessionUtil.GetSessionQueue(HttpContext);
            return View(output);
        }


        public ActionResult InsertMessage()
        {
            return View();
        }

        [HttpPost("CreateQueuePost")]
        public async Task<ActionResult> CreateQueuePost(QueueInformation queueInformation)
        {
            Util.SessionUtil.SetSessionQueue(queueInformation, HttpContext);
            Library.QueueService queueService = new Library.QueueService();
            queueService. CreateQueue(queueInformation);

            return View();       
        }

        [HttpPost("InsertMessagePost")]
        public async Task<ActionResult> InsertMessagePost(QueueInformation queueInformation)
        {
            Util.SessionUtil.SetSessionQueue(queueInformation, HttpContext);
            Library.QueueService queueService = new Library.QueueService();
            queueService.InsertMessage(queueInformation);

            return View();
        }


        public ActionResult DeleteContainer()
        {
            return View();
        }

        public async Task<ActionResult> BlobsList()
        {
            return null;
        }

        // POST: StorageController/Create
        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateContainerPost(StorageInformation storageInfo)
        {
            try
            {
                


                return null;
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadFilePost(StorageInformation storageInfo)
        {
            try
            {
                return null;
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteContainer(StorageInformation storageInfo)
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

        // GET: StorageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StorageController/Edit/5
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

        // GET: StorageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StorageController/Delete/5
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
